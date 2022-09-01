using FIASUpdate.Properties;
using JANL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FIASUpdate
{
    internal static class Program
    {
        public static string Connection => Settings.Default.SQLCS;
        public static string DBName => Settings.Default.DBName;
        public static string XMLPath => Settings.Default.XMLPath;

        public static void SaveSettings() => Settings.Default.Save();

        private static void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Defaults.Connection = Settings.Default.SQLCS;
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Settings.Default.PropertyChanged += Default_PropertyChanged;
            Settings.Default.Reload();
            Defaults.Connection = Settings.Default.SQLCS;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}