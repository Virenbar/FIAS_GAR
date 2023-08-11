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

        /// <summary>
        /// Дата выгрузки
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Имя с регионом
        /// </summary>
        public string FullName => Region != null ? $"{Name}({Region})" : Name;

        /// <summary>
        /// GUID выгрузки
        /// </summary>
        public Guid GUID { get; }

        /// <summary>
        /// Имя таблицы выгрузки
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Полный путь
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Код региона
        /// </summary>
        public string Region { get; set; }

        public override string ToString() => $"{{Name={Name},Date={Date},GUID={GUID}}}";
    }
}