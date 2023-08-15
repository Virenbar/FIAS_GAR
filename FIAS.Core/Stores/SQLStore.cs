using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FIAS.Core.Stores
{
    public abstract class SQLStore
    {
        protected SQLStore(string connection) => Connection = connection;

        public string Connection { get; set; }

        protected static SqlCommand NewProcedure([CallerMemberName] string name = null) => new SqlCommand(name)
        {
            CommandType = CommandType.StoredProcedure
        };
    }
}