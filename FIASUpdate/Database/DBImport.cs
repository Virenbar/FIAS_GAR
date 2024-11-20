using FIAS.Core.Stores;
using FIASUpdate.Models;
using JANL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FIASUpdate
{
    internal abstract class DBImport : DBClient
    {
        protected readonly SyncEvent Events;
        protected readonly FIASDatabaseStore Store = new FIASDatabaseStore(FIASProperties.SQLConnection);
        protected readonly List<FIASTable> Tables = new List<FIASTable>();
        protected IProgress<TaskProgress> SP;
        protected CancellationToken Token;

        protected DBImport()
        {
            Events = new SyncEvent(this);
        }

        protected abstract string ScanPath { get; }

        public void Import() => Import(default, default);

        public void Import(IProgress<TaskProgress> progress) => Import(progress, default);

        public abstract void Import(IProgress<TaskProgress> progress, CancellationToken token);

        protected void ScanFiles()
        {
            Tables.Clear();
            var rootFiles = Directory.EnumerateFiles(ScanPath, "*.xml")
                .Select(F => new FIASFile(F));

            var subjectFiles = Directory.EnumerateDirectories(ScanPath)
                .SelectMany(D => Directory.EnumerateFiles(D))
                .Select(F => new FIASFile(F)
                {
                    Region = Path.GetFileName(Path.GetDirectoryName(F))
                });

            var tables = Enumerable.Concat(rootFiles, subjectFiles)
               .ToLookup(F => F.Name.Contains("PARAMS") ? "PARAMS" : F.Name)
               .Select(L => new FIASTable(L.Key, L.ToList()));

            Tables.AddRange(tables);
        }

        protected void ShrinkDatabase()
        {
            var Size = DB.Size;
            SP?.Report(new TaskProgress($"Сжатие БД ({Size:N2} МБ)", 0, 0));
            Thread.Sleep(500);
            Shrink();
            SP?.Report(new TaskProgress($"БД сжата ({Size:N2} МБ -> {DB.Size:N2} МБ)"));
        }
    }
}