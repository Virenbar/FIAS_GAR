using Newtonsoft.Json.Converters;
using System;
using Newtonsoft.Json;

namespace FIASUpdate.API
{
    public class FIASInfo
    {
        public int VersionId { get; set; }
        public string TextVersion { get; set; }

        [Obsolete]
        public string FiasCompleteDbfUrl { get; set; }

        [Obsolete]
        public string FiasCompleteXmlUrl { get; set; }

        [Obsolete]
        public string FiasDeltaDbfUrl { get; set; }

        [Obsolete]
        public string FiasDeltaXmlUrl { get; set; }

        [Obsolete]
        public string Kladr4ArjUrl { get; set; }

        [Obsolete]
        public string Kladr47ZUrl { get; set; }

        public string GarXMLFullURL { get; set; }
        public string GarXMLDeltaURL { get; set; }

        [JsonConverter(typeof(FIASDateTimeConverter))]
        public DateTime Date { get; set; }
    }
    internal class FIASDateTimeConverter : IsoDateTimeConverter
    {
        public FIASDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy"; }
    }
}