namespace FIASUpdate.Properties
{
    internal partial class Settings
    {
        public static string GAR_Common => Default.XMLPath;
        public static string GAR_Delta => $@"{GAR_Common}\gar_delta_xml";
        public static string GAR_Full => $@"{GAR_Common}\gar_xml";
    }
}