using FIASUpdate.Properties;

namespace FIASUpdate
{
    internal static class FIASManager
    {
        static FIASManager()
        {
            Settings.Default.Reload();
            DBName = "FIAS_GAR";
        }

        public static string DBName { get; private set; }
        public static string DBString => Settings.Default.SQLCS;
        public static string Root => Settings.Default.XMLPath;
    }
}