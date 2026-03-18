using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FIAS.Core.Stores
{
    public abstract class SQLStore
    {
        protected SQLStore(string connection) => Connection = connection;

        /// <summary>
        /// Соединение по умолчанию
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Создаёт новую команду с именем вызывающего метода
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static SqlCommand NewProcedure([CallerMemberName] string name = null) => new SqlCommand(name)
        {
            CommandType = CommandType.StoredProcedure
        };

        /// <summary>
        /// Создаёт новый экземпляр <see cref="SQLCommandExecutor"/>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected SQLCommandExecutor Execute(SqlCommand command) => new SQLCommandExecutor(command, Connection);
    }
}