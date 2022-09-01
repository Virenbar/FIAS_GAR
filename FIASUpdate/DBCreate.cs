using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace FIASUpdate
{
    [Obsolete]
    internal class DBCreate : IDisposable
    {
        private static readonly string GAR = Program.XMLPath;
        private static readonly string GAR_XSD = GAR + @"\gar_schemas";
        private readonly Dictionary<string, DataSet> DataSets = new Dictionary<string, DataSet>();
        private readonly Database DB;
        private readonly string DBName;
        private readonly Regex R = new Regex("AS_(?<name>[a-zA-Z_]+)_");

        //Status Progress
        private readonly IProgress<TaskProgress> SP;

        public DBCreate() : this(new Progress<TaskProgress>()) { }

        public DBCreate(IProgress<TaskProgress> TaskProgress)
        {
            DBName = Program.DBName;
            SP = TaskProgress;

            SqlConnection Connection = SQL.NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
            var I = Server.Information;
        }

        public void Create()
        {
            ReadSchemas();
            DropTables();
            CreateTables();
        }

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
}