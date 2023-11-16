using FIASUpdate.Models;
using FIASUpdate.Readers;
using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace FIASUpdate
{
    internal class DBImportFull : DBImport
    {
        private readonly Dictionary<string, string> _result = new Dictionary<string, string>();
        private readonly ImportFullOptions Options;

        public DBImportFull() : this(new ImportFullOptions { OnlyEmpty = true }) { }

        public DBImportFull(ImportFullOptions options)
        {
            Options = options;
        }

        public IReadOnlyDictionary<string, string> Result => _result;
        private static string GAR_Version => $@"{FIASProperties.GAR_Full}\version.txt";

        public override void Import(IProgress<TaskProgress> progress, CancellationToken token)
        {
            SP = progress;
            Token = token;

            _result.Clear();
            ScanFiles();
            ImportTables();
            if (Options.ShrinkDatabase) { ShrinkDatabase(); }
        }

        private void AddResult(string table, string status)
        {
            _result.Add(table, status);
            OnResultAdded(new ResultAddedEventArgs(table, status));
        }

        private void ShrinkDatabase()
        {
            var Size = DB.Size;
            SP?.Report(new TaskProgress($"Сжатие БД({Size:N2} МБ)", 0, 0));
            Thread.Sleep(1000);
            DB.Shrink(1, ShrinkMethod.Default);
            DB.Refresh();
            SP?.Report(new TaskProgress($"БД сжата({Size:N2} МБ -> {DB.Size:N2} МБ)"));
        }

        #region Table Import

        protected override string ScanPath => FIASProperties.GAR_Full;

        /// <summary>
        ///
        /// </summary>
        /// <param name="target">Таблица БД</param>
        /// <param name="source">Таблица FIAS</param>
        /// <returns>Количество импортированных строк</returns>
        private long ImportTable(Table target, FIASTable source)
        {
            using (var Connection = NewConnection(DBName))
            using (var SBC = new SqlBulkCopy(Connection) { DestinationTableName = target.Name, BulkCopyTimeout = 0, NotifyAfter = 100 })
            {
                SBC.SqlRowsCopied += SBC_SqlRowsCopied;
                SBC.EnableStreaming = true;
                var names = target.Columns.Cast<Column>().Select(C => C.Name);
                foreach (var File in source.Files)
                {
                    Token.ThrowIfCancellationRequested();
                    SP?.Report(new TaskProgress($"Импорт файла: {File.FullName}", 0, 0));
                    using (var FR = new FIASReader(File.Path, names))
                    {
                        SBC.WriteToServer(FR);
                    }
                    SBC.NotifyAfter = 100;
                    var Count = SBC.RowsCopied;
                    SP?.Report(new TaskProgress($"Импорт файла завершён: {File.FullName}", Count, Count));
                    Thread.Sleep(1000);
                }
                SP?.Report(new TaskProgress($"Импорт в таблицу завершён: {target.Name}", 0, 0));
                target.Refresh();
                return target.RowCount;
            }
        }

        private void ImportTables()
        {
            var subjects = Tables
                .SelectMany(T => T.Files.Where(F => !string.IsNullOrEmpty(F.Region)).Select(F => F.Region))
                .Distinct().ToList();
            DateTime date = new DateTime(2000, 1, 1);
            if (File.Exists(GAR_Version))
            {
                DateTime.TryParse(File.ReadAllText(GAR_Version), out date);
            }
#if false
            Store.SetSubjects(subjects);
            Store.SetVersion(date);
#endif

            foreach (var Table in Tables)
            {
                // Проверка существования
                Table T = DB.Tables[Table.Name];
                if (T == null)
                {
                    AddResult(Table.Name, "Таблицы нет в БД");
                    continue;
                }
                // Проверка настроек импорта
                T.Refresh();
                if (!Store.GetCanImport(Table.Name))
                {
                    AddResult(Table.Name, $"Пропущена ({T.RowCount:N0})");
                    continue;
                }
                if (!Options.OnlyEmpty)
                {
                    T.TruncateData();
                }
                else if (T.RowCount > 0)
                {
                    AddResult(Table.Name, $"Пропущена ({T.RowCount:N0})");
                    continue;
                }

                //Импорт
                var Count = ImportTable(T, Table);
                Store.SetLastImport(Table.Name, Table.Date);
                AddResult(Table.Name, $"Импортирована ({Count:N0})");
                Thread.Sleep(2 * 1000);
            }

            Store.SetSubjects(subjects);
            Store.SetVersion(date);
        }

        private void SBC_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            SqlBulkCopy SBC = (SqlBulkCopy)sender;
            var SBCCount = (int)e.RowsCopied;
            SP?.Report(new TaskProgress(SBCCount, SBCCount));
            if (SBCCount >= 10000 && SBC.NotifyAfter != 1000) { SBC.NotifyAfter = 1000; }
        }

        #endregion Table Import

        #region Events

        protected void OnResultAdded(ResultAddedEventArgs args) => Events.PostEvent(ResultAdded, args);

        public event EventHandler<ResultAddedEventArgs> ResultAdded;

        #endregion Events
    }
    internal class ResultAddedEventArgs : EventArgs
    {
        public ResultAddedEventArgs(string table, string status)
        {
            Table = table;
            Status = status;
        }

        public string Status { get; private set; }
        public string Table { get; private set; }
    }
}