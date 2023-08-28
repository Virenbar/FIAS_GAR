using FIAS.Core.Stores;
using FIASUpdate.Models;
using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FIASUpdate
{
    internal abstract class DBImport : IDisposable
    {
        protected readonly Database DB;
        protected readonly string DBName = FIASProperties.DBName;
        protected readonly SyncEvent Events;
        protected readonly List<FIASTable> Tables = new List<FIASTable>();
        protected readonly FIASDatabaseStore Store = new FIASDatabaseStore(FIASProperties.SQLConnection);

        protected IProgress<TaskProgress> SP;
        protected CancellationToken Token;

        protected DBImport()
        {
            Events = new SyncEvent(this);

            SqlConnection Connection = NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

        protected abstract string ScanPath { get; }

        public void Import() => Import(default, default);

        public void Import(IProgress<TaskProgress> progress) => Import(progress, default);

        public abstract void Import(IProgress<TaskProgress> progress, CancellationToken token);

        protected static SqlConnection NewConnection() => NewConnection("master");

        protected static SqlConnection NewConnection(string Database)
        {
            var SCSB = new SqlConnectionStringBuilder(FIASProperties.SQLConnection)
            {
                InitialCatalog = Database,
                Encrypt = false
            };
            var connection = new SqlConnection(SCSB.ToString());
            connection.Open();
            return connection;
        }

        protected void ScanFiles()
        {
            Tables.Clear();
            var rootFiles = Directory.EnumerateFiles(ScanPath, "*.xml")
                .Select(F => new FIASFile(F));

            var subjectFiles = Directory.EnumerateDirectories(ScanPath)
                .SelectMany(D => Directory.EnumerateFiles(D))
                .Select(F => new FIASFile(F)
                {
                    Region = Path.GetFileName(Path.GetDirectoryName(F))
                });

            var tables = Enumerable.Concat(rootFiles, subjectFiles)
               .ToLookup(F => F.Name.Contains("PARAMS") ? "PARAMS" : F.Name)
               .Select(L => new FIASTable(L.Key, L.ToList()));

            Tables.AddRange(tables);
        }

        #region IDisposable
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

        #endregion IDisposable
    }
}