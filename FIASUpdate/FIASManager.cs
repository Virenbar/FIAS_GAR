using FIASUpdate.Properties;

namespace FIASUpdate
{
    internal static class FIASManager
    {
        static FIASManager()
        {
            Settings.Default.Reload();
            //Root = @"D:\Data\FIAS_GAR";
            //DBString = "Data Source=partserver2014;Initial Catalog=master;Integrated Security=True";
            DBName = "FIAS_GAR";
        }

        public static string DBName { get; private set; }
        public static string DBString => Settings.Default.SQLCS;
        public static string Root => Settings.Default.XMLPath;
    }
}