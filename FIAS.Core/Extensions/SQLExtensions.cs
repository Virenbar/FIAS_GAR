using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace FIAS.Core.Extensions
{
    public static class SQLExtensions
    {
        public static void ExecuteNonQuery(this SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                command.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(this SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                return command.ExecuteScalar();
            }
        }

        public static T ExecuteScalar<T>(this SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                return (T)command.ExecuteScalar();
            }
        }

        public static DataTable ExecuteSelect(this SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return command.ExecuteSelect(Connection);
            }
        }

        public static DataTable ExecuteSelect(this SqlCommand command, SqlConnection connection)
        {
            var Result = new DataTable { Locale = CultureInfo.CurrentCulture };
            command.Connection = connection;
            using (var Reader = command.ExecuteReader())
            {
                Result.Load(Reader);
            }
            return Result;
        }

        // private static SqlCommand NewProcedure([CallerMemberName] string name = null) => new SqlCommand(name) { CommandType = CommandType.StoredProcedure };
    }
}