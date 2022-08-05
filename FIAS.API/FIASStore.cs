using FIAS.API.Enums;
using FIAS.API.Models;
using JANL.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FIAS.API
{
    public class FIASStore
    {
        public string ConnectionString { get; set; }

        public FIASStore()
        {
        }

        public FIASStore(string connectionString) : base()
        {
            ConnectionString = connectionString;
        }

        public async Task<List<FIASRegistryAddress>> GetChilds(string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_RegistrySelectChild(GUID).ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().Select(R => FIASRegistryAddress.Parse(R)).ToList();
                }
            }
        }

        public async Task<List<FIASHierarchyItem>> GetHierarchy(FIASDivision division, string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_GetHierarchy(division, GUID).ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().Select(R => FIASHierarchyItem.Parse(R)).ToList();
                }
            }
        }

        public async Task<FIASRegistryAddress> GetObject(string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_RegistrySelect(GUID).ExecuteAsync(C))
                {
                    return FIASRegistryAddress.Parse(DT.Rows[0]);
                }
            }
        }

        public bool IsGUID(string Search)
        {
            if (Search.Length != 36) { return false; }
            return Guid.TryParse(Search, out _);
        }

        /// <summary>
        /// Поиск адреса по AddressFull или GUID
        /// </summary>
        /// <param name="division">Иерархия</param>
        /// <param name="S">Текст для поиска</param>
        /// <param name="Level">Уровень объекта</param>
        /// <param name="Limit">Максимальное кол-во строк для вывода </param>
        /// <returns></returns>
        public async Task<List<FIASRegistryAddress>> Search(FIASDivision division, string S, int? Level, int? Limit)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await (IsGUID(S)
                    ? UP_SearchRegistryByGUID(division, S, Level, Limit)
                    : UP_SearchRegistry(division, S, Level, Limit))
                    .ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().Select(R => FIASRegistryAddress.Parse(R)).ToList();
                }
            }
        }

        public async Task<Dictionary<string, string>> Statistics()
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_FIAS_Statistics().ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().ToDictionary(R => R.Field<string>("Name"), R => R.Field<string>("Value"));
                }
            }
        }

        #region SQL

        protected DataTable UP_CB_Levels()
        {
            using (var Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (var Command = new SelectProcedure())
                {
                    return Command.Execute(Connection);
                }
            }
        }

        private static SelectProcedure UP_FIAS_Statistics()
        {
            var Command = new SelectProcedure();
            return Command;
        }

        private static SelectProcedure UP_GetHierarchy(FIASDivision H, string GUID)
        {
            var Command = new SelectProcedure($"{H}.{nameof(UP_GetHierarchy)}");
            var P = Command.Parameters;
            P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
            return Command;
        }

        private static SelectProcedure UP_RegistrySelect(string GUID)
        {
            var Command = new SelectProcedure();
            var P = Command.Parameters;
            P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
            return Command;
        }

        private static SelectProcedure UP_RegistrySelectChild(string GUID)
        {
            var Command = new SelectProcedure();
            var P = Command.Parameters;
            P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
            return Command;
        }

        private static SelectProcedure UP_SearchRegistry(FIASDivision H, string Search, int? Level, int? Limit)
        {
            var Command = new SelectProcedure($"{H}.{nameof(UP_SearchRegistry)}");
            var P = Command.Parameters;
            P.Add(new SqlParameter("@Search", SqlDbType.VarChar, 500)).Value = Search;
            P.Add(new SqlParameter("@Level", SqlDbType.Int)).Value = Level;
            P.Add(new SqlParameter("@Limit", SqlDbType.Int)).Value = Limit;
            return Command;
        }

        private static SelectProcedure UP_SearchRegistryByGUID(FIASDivision H, string GUID, int? Level, int? Limit)
        {
            var Command = new SelectProcedure($"{H}.{nameof(UP_SearchRegistryByGUID)}");
            var P = Command.Parameters;
            P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
            P.Add(new SqlParameter("@Level", SqlDbType.Int)).Value = Level;
            P.Add(new SqlParameter("@Limit", SqlDbType.Int)).Value = Limit;
            return Command;
        }

        #endregion SQL
    }
}