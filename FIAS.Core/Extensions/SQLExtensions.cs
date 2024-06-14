using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FIAS.Core.Extensions
{
    public static class SQLExtensions
    {
        public static SqlParameter AddParameter(this SqlCommand command, string parameter, object value)
        {
            return command.Parameters.AddWithValue(parameter, value);
        }

        public static void ExecuteNonQuery(this SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                command.ExecuteNonQuery();
            }
        }

        public static Task ExecuteNonQueryAsync(this SqlCommand command, string connection) => ExecuteNonQueryAsync(command, connection, default);

        public static async Task ExecuteNonQueryAsync(this SqlCommand command, string connection, CancellationToken token)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                await command.ExecuteNonQueryAsync(token);
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

        public static SqlCommand SetSchema(this SqlCommand command, string schema)
        {
            var name = command.CommandText.Split('.').Last();
            command.CommandText = $"{schema}.{name}";
            return command;
        }
    }
}