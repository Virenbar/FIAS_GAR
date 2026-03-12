using FIAS.Core.API;

namespace FIASUpdate.Models
{
    /// <summary>
    /// Класс дельта архива ФИАС
    /// </summary>
    internal class FIASArchiveDelta : FIASArchive
    {
        private readonly FIASInfo Info;

        public FIASArchiveDelta(FIASInfo info)
        {
            Info = info;
            Date = info.Date;
            SetArchivePath($@"{ExtractPath}.zip");
        }

        public override string ExtractPath => $@"{FIASProperties.GAR_Delta}\{Date:yyyy.MM.dd}\gar_delta_xml";
        public string TextVersion => Info.TextVersion;
        public string URLDelta => Info.GarXMLDeltaURL;
        public string URLFull => Info.GarXMLFullURL;
        public int VersionId => Info.VersionId;
    }
}