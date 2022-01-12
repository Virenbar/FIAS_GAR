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
    internal class ImportOptions
    {
        public bool Shrink { get; set; }
        public bool Skip { get; set; }
    }

    internal class FIAS_GAR : IDisposable
    {
        private static readonly string GAR = FIASManager.Root;
        private static readonly string GAR_66 = GAR + @"\gar_xml\66";
        private static readonly string GAR_Common = GAR + @"\gar_xml";
        private static readonly string GAR_XSD = GAR + @"\gar_schemas";
        private readonly Dictionary<string, string> _result = new Dictionary<string, string>();
        private readonly Dictionary<string, DataSet> DataSets = new Dictionary<string, DataSet>();
        private readonly Database DB;
        private readonly string DBName;
        private readonly SyncEvent Events;
        private readonly Regex R = new Regex("AS_(?<name>[a-zA-Z_]+)_");

        //Status Progress
        private readonly IProgress<TaskProgress> SP;

        public FIAS_GAR() : this(new Progress<TaskProgress>()) { }

        public FIAS_GAR(IProgress<TaskProgress> TaskProgress)
        {
            DBName = FIASManager.DBName;
            Events = new SyncEvent(this);
            SP = TaskProgress;

            SqlConnection Connection = SQL.NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
            var I = Server.Information;
        }

        public IReadOnlyDictionary<string, string> Result => _result;

        public void Create()
        {
            ReadSchemas();
            DropTables();
            CreateTables();
        }

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

        #region Static

        private static DataType GetDataType(DataColumn DC)
        {
            //Костыль. В некоторых XML Boolean хранится как Integer.
            if (DC.ColumnName == "ISACTIVE" || DC.ColumnName == "ISACTUAL") { return DataType.Bit; }
            switch (DC.DataType.Name)
            {
                case nameof(Boolean): return DataType.Bit;
                case nameof(Int32): return DataType.Int;
                case nameof(Int64): return DataType.BigInt;
                case nameof(Decimal): return DataType.Money;
                case nameof(DateTime): return DataType.DateTime;
                case nameof(Guid): return DataType.UniqueIdentifier;
                case nameof(String): return DataType.VarChar(DC.MaxLength);
                default: return DataType.VarCharMax;
            }
        }

        #endregion Static

        #region Table Creation

        private void CreateTable(string Name, DataTable DT)
        {
            var T = new Table(DB, Name);
            foreach (DataColumn C in DT.Columns)
            {
                var column = new Column(T, C.ColumnName)
                {
                    DataType = GetDataType(C),
                    Nullable = C.AllowDBNull,
                    Identity = C.AutoIncrement,
                    IdentityIncrement = C.AutoIncrementStep
                };
                T.Columns.Add(column);
            }
            T.Create();
        }

        private void CreateTables()
        {
            foreach (var Item in DataSets)
            {
                SP.Report(new TaskProgress($"Создание таблицы:{Item.Key}"));
                CreateTable(Item.Key, Item.Value.Tables[0]);
                Thread.Sleep(100);
            }
        }

        private void DropTables()
        {
            foreach (var Name in DataSets.Keys)
            {
                SP.Report(new TaskProgress($"Удаление таблицы: {Name}"));
                var T = DB.Tables[Name];
                T?.Drop();
                Thread.Sleep(100);
            }
        }

        private void ReadSchemas()
        {
            foreach (var XSD in Directory.EnumerateFiles(GAR_XSD))
            {
                var Name = R.Match(XSD).Groups["name"].Value;
                SP.Report(new TaskProgress($"Чтение схемы:{Name}"));
                DataSets[Name] = new DataSet();
                DataSet DS = DataSets[Name];
                DS.ReadXmlSchema(XSD);

                //Костыль для кривых схем нормативных документов
                if (DS.Tables.Count > 1)
                {
                    DS.Tables[0].ChildRelations.Clear();
                    DS.Tables[1].Constraints.Clear();
                    DS.Tables[0].Constraints.Clear();
                    DS.Tables.RemoveAt(0);
                    var Last = DS.Tables[0].Columns.Count - 1;
                    DS.Tables[0].Columns.RemoveAt(Last);
                }
                Thread.Sleep(200);
            }
        }

        #endregion Table Creation

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
            DB.Shrink(1, ShrinkMethod.NoTruncate);
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
                    foreach (var DS in DataSets.Values) { DS.Dispose(); }
                    DB.Parent.ConnectionContext.Disconnect();
                }
                disposedValue = true;
            }
        }

        #endregion IDisposable Support
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