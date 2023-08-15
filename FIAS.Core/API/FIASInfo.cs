using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;

namespace FIAS.Core.API
{
    public class FIASInfo
    {
        /// <summary>
        /// Идентификатор версии (дата выгрузки вида yyyyMMdd)
        /// </summary>
        public int VersionId { get; set; }

        /// <summary>
        /// Описание версии файла в текстовом виде
        /// </summary>
        public string TextVersion { get; set; }

        /// <summary>
        /// URL полной версии ФИАС в формате DBF
        /// </summary>
        [Obsolete("Пустое свойство", true)]
        public string FiasCompleteDbfUrl { get; set; }

        /// <summary>
        /// URL полной версии ФИАС в формате XML
        /// </summary>
        [Obsolete("Пустое свойство", true)]
        public string FiasCompleteXmlUrl { get; set; }

        /// <summary>
        /// URL дельта версии ФИАС в формате DBF
        /// </summary>
        [Obsolete("Пустое свойство", true)]
        public string FiasDeltaDbfUrl { get; set; }

        /// <summary>
        /// URL дельта версии ФИАС в формате XML
        /// </summary>
        [Obsolete("Пустое свойство", true)]
        public string FiasDeltaXmlUrl { get; set; }

        /// <summary>
        /// URL версии КЛАДР 4 сжатого в формате ARJ
        /// </summary>
        [Obsolete]
        public string Kladr4ArjUrl { get; set; }

        /// <summary>
        /// URL версии КЛАДР 4 сжатого в формате 7Z
        /// </summary>
        [Obsolete]
        public string Kladr47ZUrl { get; set; }

        /// <summary>
        /// URL полной версии ГАР в формате XML сжатого в zip
        /// </summary>
        public string GarXMLFullURL { get; set; }

        /// <summary>
        /// URL дельта версии ГАР в формате XML сжатого в zip
        /// </summary>
        public string GarXMLDeltaURL { get; set; }

        /// <summary>
        /// Дата выгрузки
        /// </summary>
        [JsonConverter(typeof(FIASDateTimeConverter))]
        public DateTime Date { get; set; }
    }
    internal class FIASDateTimeConverter : IsoDateTimeConverter
    {
        public FIASDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy"; }
    }
}