using System.Data.SqlClient;
using System.Linq;

namespace FIAS.Core.Extensions
{
    public static class SQLExtensions
    {
        public static string DefaultConnection { get; set; }

        public static SqlParameter AddParameter(this SqlCommand command, string parameter, object value)
        {
            return command.Parameters.AddWithValue(parameter, value);
        }

        public static SqlCommand SetSchema(this SqlCommand command, string schema)
        {
            var name = command.CommandText.Split('.').Last();
            command.CommandText = $"{schema}.{name}";
            return command;
        }
    }
}