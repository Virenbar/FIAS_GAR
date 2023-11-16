using System.Collections.Generic;

namespace FIASUpdate.Models
{
    internal class ImportDeltaOptions : ImportOptions
    {
        /// <summary>
        /// Список кодов субъектов РФ
        /// </summary>
        public IEnumerable<string> Subjects { get; set; }
    }
    internal class ImportFullOptions : ImportOptions
    {
        /// <summary>
        /// Импортировать только в пустые таблицы
        /// </summary>
        public bool OnlyEmpty { get; set; }
    }
    internal class ImportOptions
    {
        /// <summary>
        /// Сжать БД после импорта
        /// </summary>
        public bool ShrinkDatabase { get; set; }
    }
}