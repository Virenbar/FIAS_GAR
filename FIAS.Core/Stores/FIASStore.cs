using FIAS.Core.Extensions;
using FIAS.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FIAS.Core.Stores
{
    /// <summary>
    /// Класс для работы с данными ФИАС
    /// </summary>
    public class FIASStore : SQLStore
    {
        private const string ENDPOINT = "https://fias.nalog.ru";

        public FIASStore(string connection) : base(connection) { }

        /// <summary>
        /// Уровни иерархии объектов
        /// </summary>
        public Task<DataTable> FIASLevels() => Task.Run(UP_CB_Levels);

        /// <summary>
        /// Получить дочерние объекты
        /// </summary>
        /// <param name="GUID">GUID родительского объекта</param>
        public Task<List<FIASRegistryAddress>> GetChilds(string GUID) => GetChilds(GUID, FIASDivision.mun);

        /// <summary>
        /// Получить дочерние объекты
        /// </summary>
        /// <param name="GUID">GUID родительского объекта</param>
        public async Task<List<FIASRegistryAddress>> GetChilds(string GUID, FIASDivision division)
        {
            using (var DT = await Task.Run(() => UP_RegistrySelectChild(GUID, division)))
                return FIASRegistryAddress.Parse(DT);
        }

        public Task<List<FIASHierarchyItem>> GetHierarchy(string GUID) => GetHierarchy(GUID, FIASDivision.mun);

        public async Task<List<FIASHierarchyItem>> GetHierarchy(string GUID, FIASDivision division)
        {
            using (var DT = await Task.Run(() => UP_GetHierarchy(GUID, division)))
                return DT.Rows.Cast<DataRow>().Select(R => FIASHierarchyItem.Parse(R)).ToList();
        }

        /// <summary>
        /// Получить внутренний код
        /// </summary>
        public long GetID(string GUID) => UP_IDByGUID(GUID);

        /// <summary>
        /// Получить объект
        /// </summary>
        public FIASRegistryAddress GetObject(string GUID) => GetObject(GUID, FIASDivision.mun);

        /// <summary>
        /// Получить объект
        /// </summary>
        public FIASRegistryAddress GetObject(string GUID, FIASDivision division)
        {
            using (var DT = UP_RegistrySelect(GUID, division))
            {
                if (DT.Rows.Count == 0) { return null; }
                return FIASRegistryAddress.Parse(DT.Rows[0]);
            }
        }

        /// <summary>
        /// Получить параметры объекта
        /// </summary>
        /// <param name="GUID">GUID объекта</param>
        public async Task<Dictionary<string, string>> GetObjectParameters(string GUID)
        {
            using (var DT = await Task.Run(() => UP_ObjectParameters(GUID)))
                return DT.ToDictionary<string, string>("Name", "Value");
        }

        /// <summary>
        /// Ссылка на страницу на fias.nalog.ru
        /// </summary>
        /// <param name="GUID">GUID объекта</param>
        public string GetPageURL(string GUID) => GetPageURL(GUID, FIASDivision.mun);

        /// <summary>
        /// Ссылка на страницу на fias.nalog.ru
        /// </summary>
        /// <param name="GUID">GUID объекта</param>
        /// <param name="division">Деление</param>
        public string GetPageURL(string GUID, FIASDivision division) => $"{ENDPOINT}/Search/IndexWithPath?objectId={GetID(GUID)}&addressType={division + 1}";

        /// <summary>
        /// Ссылка на выписку по объекту
        /// </summary>
        /// <param name="GUID">GUID объекта</param>
        public string GetPDFStatement(string GUID) => GetPDFStatement(GUID, FIASDivision.mun);

        /// <summary>
        /// Ссылка на выписку по объекту
        /// </summary>
        /// <param name="GUID">GUID объекта</param>
        /// <param name="division">Деление</param>
        public string GetPDFStatement(string GUID, FIASDivision division) => $"{ENDPOINT}/Export/ExportPdfStatement?objId={GetID(GUID)}&actual=true&division={(int)division}";

        /// <summary>
        /// Поиск адреса по AddressFull или GUID
        /// </summary>
        /// <param name="division">Деление</param>
        /// <param name="S">Текст для поиска</param>
        /// <param name="Level">Уровень объекта</param>
        /// <param name="Limit">Максимальное кол-во строк для вывода </param>
        /// <returns></returns>
        public async Task<List<FIASRegistryAddress>> Search(FIASDivision division, string S, int? Level, int? Limit)
        {
            using (var DT = await Task.Run(() => S.IsGUID() ? UP_SearchRegistryByGUID(division, S, Level, Limit) : UP_SearchRegistry(division, S, Level, Limit)))
                return FIASRegistryAddress.Parse(DT);
        }

        public async Task<Dictionary<string, string>> Statistics()
        {
            using (var DT = await Task.Run(UP_FIAS_Statistics))
                return DT.ToDictionary<string, string>("Name", "Value");
        }

        #region SQL

        private DataTable UP_CB_Levels()
        {
            using (var command = NewProcedure())
                return command.ExecuteSelect(Connection);
        }

        private DataTable UP_FIAS_Statistics()
        {
            using (var command = NewProcedure())
            {
                command.CommandTimeout = 300;
                return command.ExecuteSelect(Connection);
            }
        }

        private DataTable UP_GetHierarchy(string GUID, FIASDivision H)
        {
            using (var command = NewProcedure())
            {
                command.SetSchema($"{H}");
                command.AddParameter("@GUID", GUID);
                return command.ExecuteSelect(Connection);
            }
        }

        private long UP_IDByGUID(string GUID)
        {
            using (var command = NewProcedure())
            {
                command.AddParameter("@GUID", GUID);
                return command.ExecuteScalar<long>(Connection);
            }
        }

        private DataTable UP_ObjectParameters(string GUID)
        {
            using (var command = NewProcedure())
            {
                command.CommandTimeout = 300;
                command.AddParameter("@GUID", GUID);
                return command.ExecuteSelect(Connection);
            }
        }

        private DataTable UP_RegistrySelect(string GUID) => UP_RegistrySelect(GUID, FIASDivision.mun);

        private DataTable UP_RegistrySelect(string GUID, FIASDivision H)
        {
            using (var command = NewProcedure())
            {
                command.SetSchema($"{H}");
                command.AddParameter("@GUID", GUID);
                return command.ExecuteSelect(Connection);
            }
        }

        private DataTable UP_RegistrySelectChild(string GUID, FIASDivision H)
        {
            using (var command = NewProcedure())
            {
                command.SetSchema($"{H}");
                command.AddParameter("@GUID", GUID);
                return command.ExecuteSelect(Connection);
            }
        }

        private DataTable UP_SearchRegistry(FIASDivision H, string Search, int? Level, int? Limit)
        {
            using (var command = NewProcedure())
            {
                command.SetSchema($"{H}");
                command.AddParameter("@Search", Search);
                command.AddParameter("@Level", Level);
                command.AddParameter("@Limit", Limit);
                return command.ExecuteSelect(Connection);
            }
        }

        private DataTable UP_SearchRegistryByGUID(FIASDivision H, string GUID, int? Level, int? Limit)
        {
            using (var command = NewProcedure())
            {
                command.SetSchema($"{H}");
                command.AddParameter("@GUID", GUID);
                command.AddParameter("@Level", Level);
                command.AddParameter("@Limit", Limit);
                return command.ExecuteSelect(Connection);
            }
        }

        #endregion SQL
    }
}