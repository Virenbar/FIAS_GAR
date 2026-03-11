namespace FIASUpdate.Models
{
    /// <summary>
    /// Класс полного архива ФИАС
    /// </summary>
    internal class FIASArchiveFull : FIASArchive
    {
        public FIASArchiveFull(string path) : base(path) { }

        public override string ExtractPath => $@"{FIASProperties.GAR_Full}\{Date:yyyy.MM.dd}\gar_full_xml";

        // protected override string DirectoryPath => $@"{FIASProperties.GAR_Full}\{Date:yyyy.MM.dd}";
    }
}