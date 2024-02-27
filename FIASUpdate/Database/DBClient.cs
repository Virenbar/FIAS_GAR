using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;

namespace FIASUpdate
{
    internal abstract class DBClient : IDisposable
    {
        protected readonly Database DB;
        protected readonly string DBName = FIASProperties.DBName;

        protected DBClient()
        {
            SqlConnection Connection = NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

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