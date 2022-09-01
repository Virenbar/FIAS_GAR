using FIAS.Core.Stores;
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
        private static readonly string GAR = Program.XMLPath;
        private static readonly string GAR_Common = GAR + @"\gar_xml";
        private readonly Dictionary<string, string> _result = new Dictionary<string, string>();
        private readonly Database DB;
        private readonly string DBName;
        private readonly SyncEvent Events;
        private readonly Regex R = new Regex("AS_(?<name>[a-zA-Z_]+)_");

        //Status Progress
        private readonly IProgress<TaskProgress> SP;

        private readonly FIASStore Store = new FIASStore(Program.Connection);
        private readonly List<FIASTable> Tables = new List<FIASTable>();

        public DBImport() : this(null) { }

        public DBImport(IProgress<TaskProgress> TaskProgress)
        {
            DBName = Program.DBName;
            Events = new SyncEvent(this);
            SP = TaskProgress;

            SqlConnection Connection = SQL.NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

        public IReadOnlyDictionary<string, string> Result => _result;

        public void Import() => Import(new ImportOptions { OnlyEmpty = true });

        public void Import(ImportOptions options)
        {
            _result.Clear();
            PrepareFiles();
            ImportTables(options);
            if (options.Shrink) { ShrinkDatabase(); }
        }

        #region Table Import

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
                    SP?.Report(new TaskProgress($"Импорт файла: {File.FullName}", 0, 0));
                    using (var FR = new FIASReader(ColumnMap.Keys, File.Path))
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

        private void ImportTables(ImportOptions options)
        {
            foreach (var Table in Tables)
            {
                //Проверка существования
                Table T = DB.Tables[Table.Name];
                if (T == null)
                {
                    AddResult(Table.Name, "Таблицы нет в БД");
                    continue;
                }
                //Проверка настроек импорта
                T.Refresh();
                if (!Store.GetCanImport(Table.Name))
                {
                    AddResult(Table.Name, $"Пропущена ({T.RowCount:N0})");
                    continue;
                }
                if (!options.OnlyEmpty)
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
                Store.SetLastImport(Table.Name, options.Date);
                AddResult(Table.Name, $"Импортирована ({Count:N0})");
                Thread.Sleep(2 * 1000);
            }
        }

        private void PrepareFiles()
        {
            Tables.Clear();
            var CFiles = Directory.EnumerateFiles(GAR_Common)
                .Select(F => new XMLFile
                {
                    Name = R.Match(F).Groups["name"].Value,
                    Path = F
                });

            var Files = Directory.EnumerateDirectories(GAR_Common)
                .SelectMany(D => Directory.EnumerateFiles(D))
                .Select(F => new XMLFile
                {
                    Name = R.Match(F).Groups["name"].Value,
                    Region = Path.GetFileName(Path.GetDirectoryName(F)),
                    Path = F
                });

            Tables.AddRange(
               Enumerable.Concat(CFiles, Files)
               .ToLookup(F => F.Name.Contains("PARAMS") ? "PARAMS" : F.Name)
               .Select(L => new FIASTable
               {
                   Name = L.Key,
                   Files = L.ToList()
               }));
        }

        private void SBC_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            SqlBulkCopy SBC = (SqlBulkCopy)sender;
            var SBCCount = (int)e.RowsCopied;
            SP?.Report(new TaskProgress(SBCCount, SBCCount));
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
            SP?.Report(new TaskProgress($"Сжатие БД({Size:N2} МБ)", 0, 0));
            Thread.Sleep(1000);
            DB.Shrink(1, ShrinkMethod.Default);
            DB.Refresh();
            SP?.Report(new TaskProgress($"БД сжата({Size:N2} МБ -> {DB.Size:N2} МБ)"));
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
    internal class FIASTable
    {
        public List<XMLFile> Files { get; set; }
        public string Name { get; set; }
    }
    internal class ImportOptions
    {
        public DateTime Date { get; set; }
        public bool OnlyEmpty { get; set; }
        public bool Shrink { get; set; }
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
    internal class XMLFile
    {
        public string FullName => Region != null ? $"{Name}({Region})" : Name;
        public string Name { get; set; }
        public string Path { get; set; }
        public string Region { get; set; }
    }
}