using FIASUpdate.Models;
using JANL;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FIASUpdate
{
    /// <summary>
    /// Класс для импорта полного архива
    /// </summary>
    internal class DBImportFull : DBImport<FIASArchiveFull>
    {
        private readonly List<TableImportResult> _result = new List<TableImportResult>();

        public DBImportFull(FIASArchiveFull archive)
        {
            Archive = archive;
        }

        /// <summary>
        /// Импортировать только в пустые таблицы
        /// </summary>
        public bool OnlyEmpty { get; set; }

        /// <summary>
        /// Результат импорта таблиц
        /// </summary>
        public IReadOnlyList<TableImportResult> Result => _result;

        public override void Import(IProgress<TaskProgress> progress, CancellationToken token)
        {
            base.Import(progress, token);

            Archive.ExtractVersion();
            Extract();
            ScanFiles();
            ImportTables();
        }

        private void AddResult(string table, string status)
        {
            var result = new TableImportResult(table, status);
            _result.Add(result);
            OnResultAdded(new ResultAddedEventArgs(result));
        }

        #region Table Import

        private void ImportTables()
        {
            _result.Clear();
            foreach (var table in Tables)
            {
                // Проверка существования
                Table T = DB.Tables[table.Name];
                if (T == null)
                {
                    AddResult(table.Name, "Таблицы нет в БД");
                    continue;
                }
                // Проверка настроек импорта
                T.Refresh();
                if (!Store.GetCanImport(table.Name))
                {
                    AddResult(table.Name, $"Пропущена ({T.RowCount:N0})");
                    continue;
                }
                if (OnlyEmpty && T.RowCount > 0)
                {
                    AddResult(table.Name, $"Пропущена ({T.RowCount:N0})");
                    continue;
                }
                else
                {
                    T.TruncateData();
                }
                // Импорт
                ImportTable(T, table);
                SP?.Report(new TaskProgress($"Импорт в таблицу завершён: {T.Name}", 0, 0));
                T.Refresh();
                Store.SetLastImport(table.Name, table.Date);

                var count = T.RowCount;
                AddResult(table.Name, $"Импортирована ({count:N0})");
                Thread.Sleep(1000);
            }
            Store.SetVersion(Archive.Date);
        }

        #endregion Table Import

        #region Events

        protected void OnResultAdded(ResultAddedEventArgs args) => Events.PostEvent(ResultAdded, args);

        public event EventHandler<ResultAddedEventArgs> ResultAdded;

        #endregion Events
    }
    /// <summary>
    ///
    /// </summary>
    internal class ResultAddedEventArgs : EventArgs
    {
        public ResultAddedEventArgs(TableImportResult result)
        {
            Result = result;
        }

        public TableImportResult Result { get; }
    }
    /// <summary>
    /// Результат импорта таблицы
    /// </summary>
    internal class TableImportResult
    {
        public TableImportResult(string table, string status)
        {
            Table = table;
            Status = status;
        }

        public string Status { get; }
        public string Table { get; }
    }
}