using System;
using System.Collections.Generic;
using System.Linq;

namespace FIASUpdate.Models
{
    internal class FIASTable
    {
        public FIASTable(string name, List<XMLFile> files)
        {
            Name = name;
            Files = files;
            Date = files.Max(F => F.Date);
        }

        /// <summary>
        /// Дата выгрузки
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Список XML файлов выгрузки
        /// </summary>
        public List<XMLFile> Files { get; }

        /// <summary>
        /// Имя таблицы выгрузки
        /// </summary>
        public string Name { get; }

        public override string ToString() => $"{{Name={Name},Date={Date}}}";
    }
}