using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using FIAS.Core.Stores;
using FIASUpdate.Models;
using FIASUpdate.Readers;
using JANL;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace FIASUpdate
{
    /// <summary>
    /// Базовый класс для импорта архива
    /// </summary>
    /// <typeparam name="T">Тип архива</typeparam>
    internal abstract class DBImport<T> : DBClient where T : FIASArchive
    {
        protected readonly SyncEvent Events;
        protected readonly FIASDatabaseStore Store = new FIASDatabaseStore(FIASProperties.SQLConnection);
        protected readonly List<FIASTable> Tables = new List<FIASTable>();
        protected T Archive;
        protected IProgress<TaskProgress> SP;
        protected CancellationToken Token;

        protected DBImport()
        {
            Events = new SyncEvent(this);
        }

        /// <summary>
        /// Список кодов субъектов РФ
        /// </summary>
        public IEnumerable<string> Subjects { get; set; }

        /// <summary>
        /// Путь к папке с файлами ФИАС
        /// </summary>
        protected string ScanPath => Archive.ExtractPath;

        public void Import() => Import(default, default);

        public void Import(IProgress<TaskProgress> progress) => Import(progress, default);

        public virtual void Import(IProgress<TaskProgress> progress, CancellationToken token)
        {
            SP = progress;
            Token = token;
        }

        /// <summary>
        /// Распаковывает архив
        /// </summary>
        protected void Extract()
        {
            SP?.Report(new TaskProgress($"Распаковка архива", 0, 0));
            Archive.Extract(Subjects);
        }

        /// <summary>
        /// Импортировать в данные из <paramref name="source"/> в таблицу <paramref name="target"/>
        /// </summary>
        /// <param name="target">Таблица БД</param>
        /// <param name="source">Таблица FIAS</param>
        protected virtual void ImportTable(Table target, FIASTable source)
        {
            using (var connection = NewConnection(DBName))
            using (var SBC = new SqlBulkCopy(connection) { DestinationTableName = target.Name, BulkCopyTimeout = 0, NotifyAfter = 100 })
            {
                SBC.SqlRowsCopied += SBC_SqlRowsCopied;
                SBC.EnableStreaming = true;
                var names = target.Columns.Cast<Column>().Select(C => C.Name);
                foreach (var file in source.Files)
                {
                    Token.ThrowIfCancellationRequested();
                    SP?.Report(new TaskProgress($"Импорт файла: {file.FullName}", 0, 0));
                    using (var FR = new FIASReader(file.Path, names))
                    {
                        SBC.WriteToServer(FR);
                    }
                    SBC.NotifyAfter = 100;
                    var count = SBC.RowsCopied;
                    SP?.Report(new TaskProgress($"Импорт файла завершён: {file.FullName}", count, count));
                    Thread.Sleep(200);
                }
            }
        }

        /// <summary>
        /// Поиск файлов для импорта
        /// </summary>
        protected void ScanFiles()
        {
            // Корневые файлы
            var rootFiles = Directory.EnumerateFiles(ScanPath, "*.xml")
                .Select(F => new FIASFile(F));
            // Файлы субъектов
            var subjectFiles = Directory.EnumerateDirectories(ScanPath)
                .SelectMany(D => Directory.EnumerateFiles(D))
                .Select(F => new FIASFile(F)
                {
                    Region = Path.GetFileName(Path.GetDirectoryName(F))
                });
            // Параметры объединены в одну таблицу
            var tables = Enumerable.Concat(rootFiles, subjectFiles)
               .ToLookup(F => F.Name.Contains("PARAMS") ? "PARAMS" : F.Name)
               .Select(L => new FIASTable(L.Key, L.ToList()));

            Tables.Clear();
            Tables.AddRange(tables);
        }

        private void SBC_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            SqlBulkCopy SBC = (SqlBulkCopy)sender;
            var SBCCount = (int)e.RowsCopied;
            SP?.Report(new TaskProgress(SBCCount, SBCCount));
            if (SBCCount >= 10000 && SBC.NotifyAfter != 1000) { SBC.NotifyAfter = 1000; }
        }
    }
}