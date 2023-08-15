using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using Settings = FIASUpdate.Properties.Settings;

namespace FIASUpdate
{
    internal abstract class DBImport : IDisposable
    {
        protected static readonly Settings Settings = Settings.Default;
        protected readonly Database DB;
        protected readonly string DBName = Settings.DBName;
        protected readonly SyncEvent Events;

        protected DBImport()
        {
            Events = new SyncEvent(this);

            SqlConnection Connection = NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

        protected static SqlConnection NewConnection() => NewConnection("master");

        protected static SqlConnection NewConnection(string Database)
        {
            var SCSB = new SqlConnectionStringBuilder(Settings.SQLConnection)
            {
                InitialCatalog = Database,
                Encrypt = false
            };
            var connection = new SqlConnection(SCSB.ToString());
            connection.Open();
            return connection;
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