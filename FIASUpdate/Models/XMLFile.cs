using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FIASUpdate.Models
{
    internal class XMLFile
    {
        private static readonly Regex R = new Regex(@"AS_(?<name>[a-zA-Z_]+)_(?<date>\d{8})_(?<guid>[\w-]{36})");

        public XMLFile(string path)
        {
            var M = R.Match(path);
            if (!M.Success) { throw new ArgumentException("Не корректный формат имени файла", nameof(path)); }

            var date = M.Groups["date"].Value;
            var name = M.Groups["name"].Value;
            var guid = M.Groups["guid"].Value;

            Name = name;
            Path = path;
            GUID = new Guid(guid);
            Date = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public DateTime Date { get; }
        public string FullName => Region != null ? $"{Name}({Region})" : Name;
        public Guid GUID { get; }
        public string Name { get; }
        public string Path { get; }
        public string Region { get; set; }

        public override string ToString() => $"{{Name={Name},Date={Date},GUID={GUID}}}";
    }
}