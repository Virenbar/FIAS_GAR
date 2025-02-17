using FIASUpdate.Models;
using FIASUpdate.Readers;
using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace FIASUpdate
{
    internal class DBImportDelta : DBImport
    {
        private readonly FIASArchive Archive;
        private readonly ImportDeltaOptions Options;

        public DBImportDelta(FIASArchive archive, ImportDeltaOptions options)
        {
            Options = options;
            Archive = archive;
        }

        public override void Import(IProgress<TaskProgress> progress, CancellationToken token)
        {
            SP = progress;
            Token = token;

            Extract();
            ScanFiles();
            foreach (var item in Tables)
            {
                // Проверка существования
                var table = DB.Tables[item.Name];
                if (table == null) { continue; }
                // Проверка настроек импорта
                table.Refresh();
                if (!Store.GetCanImport(table.Name)) { continue; }

                // Импорт
                ImportTable(table, item);
                Store.SetLastImport(item.Name, item.Date);
                Thread.Sleep(500);
            }
            Store.SetVersion(Archive.Date);
            if (Options.ShrinkDatabase) { ShrinkDatabase(); }
        }

        private void Extract()
        {
            SP.Report(new TaskProgress($"Распаковка архива", 0, 0));
            Archive.Extract(Options.Subjects);
        }

        #region Table Import

        protected override string ScanPath => Archive.ExtractPath;

        /// <summary>
        ///
        /// </summary>
        /// <param name="target">Таблица БД</param>
        /// <param name="source">Таблица FIAS</param>
        /// <returns>Количество импортированных строк</returns>
        private long ImportTable(Table target, FIASTable source)
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
            var columns = target.Columns.Cast<Column>();
            using (var connection = NewConnection(DBName))
            using (var SBC = new SqlBulkCopy(connection) { DestinationTableName = temporaryTable.Name, BulkCopyTimeout = 0, NotifyAfter = 100 })
            {
                SBC.SqlRowsCopied += SBC_SqlRowsCopied;
                SBC.EnableStreaming = true;
                var names = target.Columns.Cast<Column>().Select(C => C.Name);
                foreach (var File in source.Files)
                {
                    Token.ThrowIfCancellationRequested();
                    SP?.Report(new TaskProgress($"Импорт файла: {File.FullName}", 0, 0));
                    using (var FR = new FIASReader(File.Path, names))
                    {
                        SBC.WriteToServer(FR);
                    }
                    SBC.NotifyAfter = 100;
                    var Count = SBC.RowsCopied;
                    SP.Report(new TaskProgress($"Импорт файла завершён: {File.FullName}", Count, Count));
                    Thread.Sleep(200);
                }
            }

            SP.Report(new TaskProgress($"Объединение таблиц: {target.Name}", 0, 0));
            // Объединить таблицы
            var key = columns.First().Name;
            var insert = columns.Select(C => $"[{C.Name}]");
            var values = columns.Select(C => $"[S].[{C.Name}]");
            var update = columns.Skip(1).Select(C => $"[{C.Name}] = [S].[{C.Name}]");

            var query = new StringBuilder();
            query.AppendLine($"MERGE INTO [{target.Name}] AS [T]");
            query.AppendLine($"USING [{temporaryName}] AS [S]");
            query.AppendLine($"ON([T].[{key}] = [S].[{key}])");
            query.AppendLine("WHEN NOT MATCHED BY TARGET THEN");
            query.AppendLine($"INSERT ({string.Join(",", insert)})");
            query.AppendLine($"VALUES ({string.Join(",", values)})");
            query.AppendLine("WHEN MATCHED THEN");
            query.AppendLine($"UPDATE SET { string.Join(",", update)};");
            DB.ExecuteNonQuery(query.ToString());

            temporaryTable.Drop();
            SP.Report(new TaskProgress($"Импорт в таблицу завершён: {target.Name}", 0, 0));
            target.Refresh();
            return target.RowCount;
        }

        private void SBC_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            SqlBulkCopy SBC = (SqlBulkCopy)sender;
            var SBCCount = (int)e.RowsCopied;
            SP.Report(new TaskProgress(SBCCount, SBCCount));
            if (SBCCount >= 10000 && SBC.NotifyAfter != 1000) { SBC.NotifyAfter = 1000; }
        }

        #endregion Table Import
    }
}