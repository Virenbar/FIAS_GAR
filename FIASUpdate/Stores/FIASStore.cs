using FIASUpdate.Enums;
using FIASUpdate.Models;
using JANL.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FIASUpdate.Stores
{
    public static class FIASStore
    {
        public static async Task<List<FIASRegistryAddress>> GetChilds(string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_RegistrySelectChild(GUID).ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().Select(R => FIASRegistryAddress.Parse(R)).ToList();
                }
            }
        }

        public static async Task<List<FIASHierarchyItem>> GetHierarchy(string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_RegistrySelect(GUID).ExecuteAsync(C))
                {
                    return DT.Rows.Cast<DataRow>().Select(R => FIASHierarchyItem.Parse(R)).ToList();
                }
            }
        }

        public static async Task<FIASRegistryAddress> GetObject(string GUID)
        {
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_RegistrySelect(GUID).ExecuteAsync(C))
                {
                    return FIASRegistryAddress.Parse(DT.Rows[0]);
                }
            }
        }

        public static bool IsGUID(string Search)
        {
            if (Search.Length != 36) { return false; }
            return Guid.TryParse(Search, out var G);
        }

        public static async Task<List<FIASRegistryAddress>> Search(FIASDivision division, string S, int? Level, int? Limit)
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

        public static async Task<Dictionary<string, string>> Statistics()
        {
            var D = new Dictionary<string, string>();
            using (var C = SQLHelper.NewConnection())
            {
                using (var DT = await UP_FIAS_Statistics().ExecuteAsync(C))
                {
                    foreach (DataRow R in DT.Rows) { D.Add(R.Field<string>("Name"), R.Field<string>("Value")); }
                }
            }
            return D;
        }

        #region SQL

        public static SelectProcedure UP_CB_Levels()
        {
            var Command = new SelectProcedure();
            return Command;
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