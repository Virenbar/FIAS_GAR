using System.Data.SqlClient;
using FIASUpdate.Properties;

namespace FIASUpdate
{
    internal static class FIASProperties
    {
        public static string DatabaseName { get; private set; }
        public static string GAR_Delta => $@"{GAR_Common}\gar_delta_xml";
        public static string GAR_Full => $@"{GAR_Common}\gar_xml";
        public static string GAR_XSD => $@"{GAR_Common}\gar_schemas";
        public static string ServerName { get; private set; }
        public static string SQLConnection => Settings.Default.SQLConnection;
        private static string GAR_Common => Settings.Default.XMLPath;

        public static void Refresh()
        {
            var connection = new SqlConnectionStringBuilder(SQLConnection);
            ServerName = connection.DataSource;
            DatabaseName = connection.InitialCatalog;
        }
    }
}