using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;

namespace FIASUpdate
{
    internal class DBClient : IDisposable
    {
        protected readonly Database DB;
        protected readonly string DBName = FIASProperties.DBName;

        public DBClient()
        {
            //AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.EnableSecureProtocolsByOS", true);
            SqlConnection Connection = NewConnection();
            Server Server = new Server(new ServerConnection(Connection));
            //var SCSB = new SqlConnectionStringBuilder(FIASProperties.SQLConnection);
            //Server Server = new Server(new ServerConnection(SCSB.DataSource));
            DB = Server.Databases[DBName];
            if (DB == null) { throw new InvalidOperationException($"База данных {DBName} не найдена"); }
            DB.Refresh();
        }

        public double Size => DB.Size;

        public void Shrink()
        {
            DB.Shrink(1, ShrinkMethod.Default);
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