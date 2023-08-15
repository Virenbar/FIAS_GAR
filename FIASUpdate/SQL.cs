using FIASUpdate.Properties;
using Microsoft.Data.SqlClient;

namespace FIASUpdate
{
    internal static class SQL
    {
        private static readonly Settings Settings = Settings.Default;

        public static SqlConnection NewConnection() => NewConnection("master");

        public static SqlConnection NewConnection(string Database)
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
    }
}