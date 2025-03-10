﻿using FIAS.Core.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FIASUpdate.Models
{
    internal class FIASArchive
    {
        private readonly FileInfo File;
        private readonly FIASInfo Info;

        public FIASArchive(FIASInfo info)
        {
            Info = info;
            File = new FileInfo(ArchivePath);
            Refresh();
        }

        public string ArchivePath => $@"{DirectoryPath}\gar_delta_xml.zip";
        public long? ArchiveSize { get; set; }
        public DateTime Date => Info.Date;
        public bool Exsists { get; private set; }
        public string ExtractPath => $@"{DirectoryPath}\gar_delta_xml";
        public string TextVersion => Info.TextVersion;
        public string URLDelta => Info.GarXMLDeltaURL;
        public string URLFull => Info.GarXMLFullURL;
        public int VersionId => Info.VersionId;
        private string DirectoryPath => $@"{FIASProperties.GAR_Delta}\{Date:yyyy.MM.dd}";

        public void Extract(IEnumerable<string> subjects)
        {
            var path = ArchivePath;
            using (var zip = ZipFile.OpenRead(path))
            {
                var root = zip.Entries.Where(E => !E.FullName.Contains(@"/"));
                var files = zip.Entries.Where(E => subjects.Any(S => E.FullName.Contains($@"{S}/")));

                foreach (var item in root.Concat(files))
                {
                    var file = Path.Combine(ExtractPath, item.FullName);
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
                    item.ExtractToFile(file, true);
                }
            }
        }

        public void Refresh()
        {
            File.Refresh();
            Exsists = File.Exists && IsValid();
            if (Exsists)
            {
                ArchiveSize = File.Length;
            }
        }

        private bool IsValid()
        {
            try
            {
                // Попробовать открыть для проверки целостности
                // Выдаст ошибку если файл в процессе записи или повреждён
                // Может зависнуть на повреждённом архиве
                // Нужна проверка хэша, но увы. Хэш в сделку не входил
                using (var zip = ZipFile.OpenRead(File.FullName))
                {
                    return zip.Entries.Count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}