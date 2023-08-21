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
        private FIASInfo Info;

        public FIASArchive(FIASInfo info)
        {
            Info = info;
        }

        public string DirectoryPath => $@"{ArchivePath}\gar_delta_xml";
        public string FilePath => $@"{ArchivePath}\gar_delta_xml.zip";
        public DateTime Date => Info.Date;
        public string TextVersion => Info.TextVersion;
        public string URLDelta => Info.GarXMLDeltaURL;
        public int VersionId => Info.VersionId;
        private string ArchivePath => $@"{Settings.GAR_Delta}\{Date:yyyy.MM.dd}";

        public void Extract(IEnumerable<string> subjects)
        {
            var path = FilePath;
            using (var zip = ZipFile.OpenRead(path))
            {
                var root = zip.Entries.Where(E => !E.FullName.Contains(@"\"));
                var files = zip.Entries.Where(E => subjects.Any(S => E.FullName.Contains($@"{S}\")));

                foreach (var item in root.Concat(files))
                {
                    item.ExtractToFile(Path.Combine(DirectoryPath, item.FullName));
                }
                //var subjectsFiles = zip.Entries
            }
        }

        public bool IsExsists()
        {
            var path = FilePath;
            if (!File.Exists(path)) { return false; }
            try
            {
                using (var zip = ZipFile.OpenRead(path))
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