using Microsoft.Data.SqlClient;

namespace FIASUpdate
{
    internal static class SQL
    {
        public static SqlConnection NewConnection() => NewConnection("master");

        public static SqlConnection NewConnection(string Database)
        {
            var SCSB = new SqlConnectionStringBuilder(FIASManager.DBString)
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