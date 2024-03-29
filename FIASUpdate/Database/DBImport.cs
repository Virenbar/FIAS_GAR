﻿using FIAS.Core.Stores;
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
        protected readonly List<FIASTable> Tables = new List<FIASTable>();
        protected readonly FIASDatabaseStore Store = new FIASDatabaseStore(FIASProperties.SQLConnection);

        protected IProgress<TaskProgress> SP;
        protected CancellationToken Token;

        protected DBImport() : base()
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
    }
}