using FIASUpdate.Models;
using JANL;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace FIASUpdate
{
    /// <summary>
    /// Класс для импорта дельта архива
    /// </summary>
    internal class DBImportDelta : DBImport<FIASArchiveDelta>
    {
        public DBImportDelta(FIASArchiveDelta archive)
        {
            Archive = archive;
        }

        public override void Import(IProgress<TaskProgress> progress, CancellationToken token)
        {
            base.Import(progress, token);

            Extract();
            ScanFiles();
            ImportTables();
        }

        #region Table Import

        /// <summary>
        ///
        /// </summary>
        /// <param name="target">Таблица БД</param>
        /// <param name="source">Таблица FIAS</param>
        protected override void ImportTable(Table target, FIASTable source)
        {
            // Создать временную таблицу
            var temporaryName = $"_{target.Name}";
            var temporaryTable = DB.Tables[temporaryName];
            temporaryTable?.Drop();
            temporaryTable = new Table(DB, temporaryName);
            foreach (Column column in target.Columns)
            { column.CloneTo(temporaryTable); }
            temporaryTable.Create();

            // Импортировать данные во временную таблицу
            base.ImportTable(temporaryTable, source);

            SP?.Report(new TaskProgress($"Объединение таблиц: {target.Name}", 0, 0));
            // Объединить таблицы
            var columns = target.Columns.Cast<Column>();
            var key = columns.First().Name;
            var insert = columns.Select(C => $"[{C.Name}]");
            var values = columns.Select(C => $"[S].[{C.Name}]");
            var update = columns.Skip(1).Select(C => $"[{C.Name}] = [S].[{C.Name}]");

            var query = new StringBuilder()
                .AppendLine($"MERGE INTO [{target.Name}] AS [T]")
                .AppendLine($"USING [{temporaryName}] AS [S]")
                .AppendLine($"ON([T].[{key}] = [S].[{key}])")
                .AppendLine("WHEN NOT MATCHED BY TARGET THEN")
                .AppendLine($"INSERT ({string.Join(",", insert)})")
                .AppendLine($"VALUES ({string.Join(",", values)})")
                .AppendLine("WHEN MATCHED THEN")
                .AppendLine($"UPDATE SET {string.Join(",", update)};");
            DB.ExecuteNonQuery(query.ToString());

            temporaryTable.Drop();
        }

        private void ImportTables()
        {
            foreach (var table in Tables)
            {
                // Проверка существования
                var T = DB.Tables[table.Name];
                if (T == null) { continue; }
                // Проверка настроек импорта
                T.Refresh();
                if (!Store.GetCanImport(T.Name)) { continue; }

                // Импорт
                ImportTable(T, table);
                SP?.Report(new TaskProgress($"Импорт в таблицу завершён: {T.Name}", 0, 0));
                Store.SetLastImport(table.Name, table.Date);
                Thread.Sleep(500);
            }
            Store.SetVersion(Archive.Date);
        }

        #endregion Table Import
    }
}