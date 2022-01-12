using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASUpdate
{
    internal static class SQL
    {
        public static SqlConnection NewConnection() => NewConnection("master");

        public static SqlConnection NewConnection(string Database)
        {
            var SCSB = new SqlConnectionStringBuilder(FIASManager.DBString)
            {
                InitialCatalog = Database
            };
            var connection = new SqlConnection(SCSB.ToString());
            connection.Open();
            return connection;
        }
    }
}