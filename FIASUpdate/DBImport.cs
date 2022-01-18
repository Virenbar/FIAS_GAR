using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace FIASUpdate
{
    internal class DBImport : IDisposable
    {
        private static readonly string GAR = FIASManager.Root;
        private static readonly string GAR_66 = GAR + @"\gar_xml\66";
        private static readonly string GAR_Common = GAR + @"\gar_xml";
        private readonly Dictionary<string, string> _result = new Dictionary<string, string>();

        private readonly Database DB;
        private readonly string DBName;
        private readonly SyncEvent Events;
        private readonly Regex R = new Regex("AS_(?<name>[a-zA-Z_]+)_");

        //Status Progress
        private readonly IProgress<TaskProgress> SP;

        public DBImport() : this(new Progress<TaskProgress>()) { }

        public DBImport(IProgress<TaskProgress> TaskProgress)
        {
            DBName = FIASManager.DBName;
            Events = new SyncEvent(this);
            SP = TaskProgress;

            SqlConnection Connection = SQL.NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

        public IReadOnlyDictionary<string, string> Result => _result;

        public void Import() => Import(new ImportOptions { Skip = true });

        public void Import(ImportOptions options)
        {
            _result.Clear();
            ImportTables(options.Skip);
            if (options.Shrink)
            {
                ShrinkDatabase();
            }
        }

        #region Table Import

        private int ImportTable(Table T, string File)
        {
            SP.Report(new TaskProgress($"Импорт в таблицу: {T.Name}"));
            Dictionary<string, string> ColumnMap = T.Columns.Cast<Column>().ToDictionary((C) => C.Name, (C) => C.Name);

            using (var FR = new FIASReader(ColumnMap.Keys, File))
            using (var Connection = SQL.NewConnection(DBName))
            using (var SBC = new SqlBulkCopy(Connection) { DestinationTableName = T.Name, BulkCopyTimeout = 0, NotifyAfter = 100 })
            {
                SBC.SqlRowsCopied += SBC_SqlRowsCopied;
                SBC.EnableStreaming = true;
                SBC.WriteToServer(FR);
                var Count = SBC.RowsCopied;
                SP.Report(new TaskProgress($"Импорт в таблицу завершён: {T.Name}", Count, Count));
                return Count;
            }
        }

        private void ImportTables(bool OnlyEmpty)
        {
            HashSet<string> Prepared = new HashSet<string>();

            var Files = new List<string>(Directory.EnumerateFiles(GAR_Common));
            Files.AddRange(Directory.EnumerateFiles(GAR_66));
            foreach (var File in Files)
            {
                //Имя таблицы и файла
                string FileName = R.Match(File).Groups["name"].Value;
                string TableName = FileName;
                if (FileName.Contains("PARAMS")) { FileName = $"PARAMS({FileName})"; TableName = "PARAMS"; }
                //Проверка существования
                Table T = DB.Tables[TableName];
                if (T is null)
                {
                    AddResult(FileName, "Таблицы нет в БД");
                    continue;
                }
                //Проверка настроек импорта
                T.Refresh();
                if (!Prepared.Contains(T.Name) && !OnlyEmpty)
                {
                    T.TruncateData();
                    Prepared.Add(T.Name);
                }
                else if (!Prepared.Contains(T.Name) && OnlyEmpty && T.RowCount > 0)
                {
                    AddResult(FileName, $"Пропущена({T.RowCount:N0})");
                    continue;
                }
                else
                {
                    Prepared.Add(T.Name);
                }
                //Импорт
                var Count = ImportTable(T, File);
                AddResult(FileName, $"Импортирована({Count:N0})");
                Thread.Sleep(2 * 1000);
            }
        }

        private void SBC_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            SqlBulkCopy SBC = (SqlBulkCopy)sender;
            var SBCCount = (int)e.RowsCopied;
            SP.Report(new TaskProgress(SBCCount, SBCCount));
            if (SBCCount >= 10000 && SBC.NotifyAfter != 1000) { SBC.NotifyAfter = 1000; }
        }

        #endregion Table Import

        private void AddResult(string table, string status)
        {
            _result.Add(table, status);
            OnResultAdded(new ResultAddedEventArgs(table, status));
        }

        private void ShrinkDatabase()
        {
            var Size = DB.Size;
            SP.Report(new TaskProgress($"Сжатие БД({Size:N2} МБ)", 0, 0));
            Thread.Sleep(1000);
            DB.Shrink(1, ShrinkMethod.Default);
            DB.Refresh();
            SP.Report(new TaskProgress($"БД сжата({Size:N2} МБ -> {DB.Size:N2} МБ)"));
        }

        #region Events

        protected void OnResultAdded(ResultAddedEventArgs args) => Events.PostEvent(ResultAdded, args);

        public event EventHandler<ResultAddedEventArgs> ResultAdded;

        #endregion Events

        #region IDisposable Support
        private bool disposedValue;

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DB.Parent.ConnectionContext.Disconnect();
                }
                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
    internal class ImportOptions
    {
        public bool Shrink { get; set; }
        public bool Skip { get; set; }
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