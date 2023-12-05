using FIAS.Core.API;
using FIASUpdate.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FIASUpdate.Models
{
    internal class FIASArchive
    {
        private readonly FileInfo Archive;
        private readonly FIASInfo Info;

        public FIASArchive(FIASInfo info)
        {
            Info = info;
            Archive = new FileInfo(ArchivePath);
            Refresh();
        }

        public string ArchivePath => $@"{DirectoryPath}\gar_delta_xml.zip";
        public long? ArchiveSize => Archive.Exists ? Archive.Length : (long?)null;
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
            Archive.Refresh();
            Exsists = Archive.Exists && IsValid();
        }

        private bool IsValid()
        {
            try
            {
                // Попробовать открыть для проверки целостности
                // Выдаст ошибку если файл в процессе записи
                // Может зависнуть на повреждённом архиве
                // Нужна проверка хэша, но увы
                using (var zip = ZipFile.OpenRead(Archive.FullName))
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