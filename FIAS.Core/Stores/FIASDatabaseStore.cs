using FIAS.Core.Extensions;
using FIAS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FIAS.Core.Stores
{
    /// <summary>
    /// Класс для работы с БД ФИАС
    /// </summary>
    public class FIASDatabaseStore : SQLStore
    {
        private const string CanImport = "CanImport";
        private const string LastImport = "LastImport";
        private const string Subjects = "Subjects";
        private const string Version = "Version";

        public FIASDatabaseStore(string connection) : base(connection) { }

        /// <summary>
        /// Получить статус разрешения импорта таблицы
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        public bool GetCanImport(string table) => (bool)UP_TablePropertyGet(table, CanImport);

        /// <summary>
        /// Получать дату импорта таблицы
        /// </summary>
        public DateTime? GetLastImport(string table) => (DateTime?)UP_TablePropertyGet(table, LastImport);

        /// <summary>
        /// Получить список субъектов
        /// </summary>
        public List<string> GetSubjects()
        {
            var list = UP_DatabasePropertyGet<string>(Subjects) ?? "";
            return list.Split(';').ToList();
        }

        /// <summary>
        /// Получить версию БД
        /// </summary>
        public DateTime? GetVersion() => UP_DatabasePropertyGet<DateTime?>(Version);

        /// <summary>
        /// Обновить реестр адресов
        /// </summary>
        /// <param name="division">Тип реестра</param>
        public Task RefreshRegistry(FIASDivision division) => RefreshRegistry(division, default);

        /// <summary>
        /// Обновить реестр адресов
        /// </summary>
        /// <param name="division">Тип реестра</param>
        public Task RefreshRegistry(FIASDivision division, CancellationToken token) => UP_RefreshRegistry(division, token);

        /// <summary>
        /// Задать статус разрешения импорта таблицы
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        public void SetCanImport(string table, bool value) => UP_TablePropertySet(table, CanImport, value);

        /// <summary>
        /// Задать дату импорта таблицы
        /// </summary>
        public void SetLastImport(string table, DateTime date) => UP_TablePropertySet(table, LastImport, date);

        /// <summary>
        /// Задать список регионов
        /// </summary>
        public void SetSubjects(List<string> regions)
        {
            var list = string.Join(";", regions);
            UP_DatabasePropertySet(Subjects, list);
        }

        /// <summary>
        /// Задать версию БД
        /// </summary>
        public void SetVersion(DateTime version) => UP_DatabasePropertySet(Version, version);

        /// <summary>
        /// Информация о таблицах в БД
        /// </summary>
        public List<FIASTableInfo> TablesInfo()
        {
            using (var DT = UP_TablesInfo())
                return FIASTableInfo.Parse(DT);
        }

        #region SQL

        private T UP_DatabasePropertyGet<T>(string name)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Name", name);
                return Command.ExecuteScalar<T>(Connection);
            }
        }

        private void UP_DatabasePropertySet(string name, object value)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Name", name);
                P.AddWithValue("@Value", value);
                Command.ExecuteNonQuery(Connection);
            }
        }

        private async Task UP_RefreshRegistry(FIASDivision division, CancellationToken token)
        {
            using (var Command = NewProcedure())
            {
                Command.SetSchema($"{division}");
                Command.CommandTimeout = 0;
                await Command.ExecuteNonQueryAsync(Connection, token);
            }
        }

        private object UP_TablePropertyGet(string table, string name)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Table", table);
                P.AddWithValue("@Name", name);
                return Command.ExecuteScalar(Connection);
            }
        }

        private void UP_TablePropertySet(string table, string name, object value)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Table", table);
                P.AddWithValue("@Name", name);
                P.AddWithValue("@Value", value);
                Command.ExecuteNonQuery(Connection);
            }
        }

        private DataTable UP_TablesInfo()
        {
            using (var Command = NewProcedure())
                return Command.ExecuteSelect(Connection);
        }

        #endregion SQL
    }
}