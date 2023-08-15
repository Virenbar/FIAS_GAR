using FIAS.Core.Stores;
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
using Settings = FIASUpdate.Properties.Settings;

namespace FIASUpdate
{
    internal class DBImportFull : DBImport
    {
        private readonly Dictionary<string, string> _result = new Dictionary<string, string>();
        private readonly ImportOptions Options;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);
        private readonly List<FIASTable> Tables = new List<FIASTable>();

        private IProgress<TaskProgress> SP;
        private CancellationToken Token;

        public DBImportFull() : this(new ImportOptions { OnlyEmpty = true }) { }

        public DBImportFull(ImportOptions options)
        {
            Options = options;
        }

        public IReadOnlyDictionary<string, string> Result => _result;
        private static string GAR_Common => Settings.XMLPath;
        private static string GAR_Full => $@"{GAR_Common}\gar_xml";
        private static string GAR_Version => $@"{GAR_Full}\Version.txt";

        public void Import() => Import(default, default);

        public void Import(IProgress<TaskProgress> progress) => Import(progress, default);

        public void Import(IProgress<TaskProgress> progress, CancellationToken token)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="T">Таблица БД</param>
        /// <param name="Table">Таблица FIAS</param>
        /// <returns>Количество импортированных строк</returns>
        private long ImportTable(Table T, FIASTable Table)
        {
            Dictionary<string, string> ColumnMap = T.Columns.Cast<Column>().ToDictionary(C => C.Name, C => C.Name);

            using (var Connection = SQL.NewConnection(DBName))
            using (var SBC = new SqlBulkCopy(Connection) { DestinationTableName = T.Name, BulkCopyTimeout = 0, NotifyAfter = 100 })
            {
                SBC.SqlRowsCopied += SBC_SqlRowsCopied;
                SBC.EnableStreaming = true;
                foreach (var File in Table.Files)
                {
                    Token.ThrowIfCancellationRequested();
                    SP?.Report(new TaskProgress($"Импорт файла: {File.FullName}", 0, 0));
                    using (var FR = new FIASReader(File.Path, ColumnMap.Keys))
                    {
                        SBC.WriteToServer(FR);
                    }
                    SBC.NotifyAfter = 100;
                    var Count = SBC.RowsCopied;
                    SP?.Report(new TaskProgress($"Импорт файла завершён: {File.FullName}", Count, Count));
                    Thread.Sleep(1000);
                }
                SP?.Report(new TaskProgress($"Импорт в таблицу завершён: {T.Name}", 0, 0));
                T.Refresh();
                return T.RowCount;
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

        private void ScanFiles()
        {
            Tables.Clear();
            var CFiles = Directory.EnumerateFiles(GAR_Full, "*.xml")
                .Select(F => new XMLFile(F));

            var Files = Directory.EnumerateDirectories(GAR_Full)
                .SelectMany(D => Directory.EnumerateFiles(D))
                .Select(F => new XMLFile(F)
                {
                    Region = Path.GetFileName(Path.GetDirectoryName(F))
                });

            var T = Enumerable.Concat(CFiles, Files)
               .ToLookup(F => F.Name.Contains("PARAMS") ? "PARAMS" : F.Name)
               .Select(L => new FIASTable(L.Key, L.ToList()));

            Tables.AddRange(T);
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

    internal class ImportOptions
    {
        /// <summary>
        /// Импортировать только в пустые таблицы
        /// </summary>
        public bool OnlyEmpty { get; set; }

        /// <summary>
        /// Сжать БД после импорта
        /// </summary>
        public bool ShrinkDatabase { get; set; }
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