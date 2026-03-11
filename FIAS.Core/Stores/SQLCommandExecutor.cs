using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace FIAS.Core
{
    public class SQLCommandExecutor
    {
        public SQLCommandExecutor(SqlCommand command, string connection)
        {
            Command = command;
            Connection = connection;
        }

        public SqlCommand Command { get; }

        public string Connection { get; set; }

        /// <summary>
        /// https://dba.stackexchange.com/questions/9840/why-would-set-arithabort-on-dramatically-speed-up-a-query
        /// https://dba.stackexchange.com/questions/2500/make-sqlclient-default-to-arithabort-on
        /// </summary>
        /// <param name="connection"></param>
        private static void SetARITHABORT(SqlConnection connection)
        {
            SqlCommand ARITHABORT = new SqlCommand("SET ARITHABORT ON", connection);
            ARITHABORT.ExecuteNonQuery();
        }

        #region NonQuery

        /// <summary>
        /// Выполнить с соединением по умолчанию
        /// </summary>
        public void NonQuery() => NonQuery(Connection);

        /// <summary>
        /// Выполнить с указанным соединением
        /// </summary>
        public void NonQuery(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Выполнить асинхронно с соединением по умолчанию
        /// </summary>
        public async Task NonQueryAsync(CancellationToken token) => await NonQueryAsync(Connection, token);

        /// <summary>
        /// Выполнить асинхронно с соединением по умолчанию
        /// </summary>
        public async Task NonQueryAsync() => await NonQueryAsync(Connection);

        /// <summary>
        /// Выполнить асинхронно с указанным соединением
        /// </summary>
        public async Task NonQueryAsync(string connection, CancellationToken token)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                await Command.ExecuteNonQueryAsync(token);
            }
        }

        /// <summary>
        /// Выполнить асинхронно с указанным соединением
        /// </summary>
        public async Task NonQueryAsync(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                await Command.ExecuteNonQueryAsync();
            }
        }

        #endregion NonQuery

        #region Scalar

        public object Scalar() => Scalar(Connection);

        public object Scalar(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                return Command.ExecuteScalar();
            }
        }

        public T Scalar<T>() => Scalar<T>(Connection);

        public T Scalar<T>(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                return (T)Command.ExecuteScalar();
            }
        }

        #endregion Scalar

        #region ScalarFunction

        public T ScalarFunction<T>() => ScalarFunction<T>(Connection);

        public T ScalarFunction<T>(string connection)
        {
            var result = Command.Parameters.Add(new SqlParameter("@Result", default(T)) { Direction = ParameterDirection.ReturnValue });
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.ExecuteNonQuery();
                if (result.Value == DBNull.Value) { return default; }
                return (T)result.Value;
            }
        }

        #endregion ScalarFunction

        #region Select

        public DataTable Select() => Select(Connection);

        public DataTable Select(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return Select(Connection);
            }
        }

        public Task<DataTable> SelectAsync() => SelectAsync(Connection);

        public async Task<DataTable> SelectAsync(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return await SelectAsync(Connection);
            }
        }

        private DataTable Select(SqlConnection connection)
        {
            var Result = new DataTable { Locale = CultureInfo.CurrentCulture };
            Command.Connection = connection;
            using (var Reader = Command.ExecuteReader())
            {
                Result.Load(Reader);
            }
            return Result;
        }

        private async Task<DataTable> SelectAsync(SqlConnection connection)
        {
            var Result = new DataTable { Locale = CultureInfo.CurrentCulture };
            Command.Connection = connection;
            using (var Reader = await Command.ExecuteReaderAsync())
            {
                await Task.Run(() => Result.Load(Reader));
            }
            return Result;
        }

        #endregion Select

        #region Select<T>

        public T Select<T>() where T : DataTable, new() => Select<T>(Connection);

        public T Select<T>(string connection) where T : DataTable, new()
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return Select<T>(Connection);
            }
        }

        public Task<T> SelectAsync<T>() where T : DataTable, new() => SelectAsync<T>(Connection);

        public async Task<T> SelectAsync<T>(string connection) where T : DataTable, new()
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return await SelectAsync<T>(Connection);
            }
        }

        private T Select<T>(SqlConnection connection) where T : DataTable, new()
        {
            var Result = new T { Locale = CultureInfo.CurrentCulture };
            Command.Connection = connection;
            using (var Reader = Command.ExecuteReader())
            {
                Result.Load(Reader);
            }
            return Result;
        }

        private async Task<T> SelectAsync<T>(SqlConnection connection) where T : DataTable, new()
        {
            var Result = new T { Locale = CultureInfo.CurrentCulture };
            Command.Connection = connection;
            using (var Reader = await Command.ExecuteReaderAsync())
            {
                await Task.Run(() => Result.Load(Reader));
            }
            return Result;
        }

        #endregion Select<T>

        #region SelectRow

        public TResult SelectRow<TResult>(Func<DataRow, TResult> selector, SqlConnection connection)
        {
            using (var Result = Select(connection))
            {
                var row = Result.Rows.Count > 0 ? Result.Rows[0] : null;
                return selector(row);
            }
        }

        public DataRow SelectRow() => SelectRow(Connection);

        public DataRow SelectRow(string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return SelectRow(Connection);
            }
        }

        private DataRow SelectRow(SqlConnection connection)
        {
            //var Result = new DataTable { Locale = CultureInfo.CurrentCulture };
            //Command.Connection = connection;
            //using (var Reader = Command.ExecuteReader())
            //{
            //    Result.Load(Reader);
            //}
            var Result = Select(connection);
            return Result.Rows.Count > 0 ? Result.Rows[0] : null;
        }

        #endregion SelectRow

        #region Reader

        public SqlDataReader Reader() => Reader(Connection);

        public SqlDataReader Reader(string connection)
        {
            var Connection = new SqlConnection(connection);
            Connection.Open();
            return Reader(Connection);
        }

        private SqlDataReader Reader(SqlConnection connection)
        {
            Command.Connection = connection;
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion Reader
    }
}