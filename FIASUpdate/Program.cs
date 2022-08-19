using FIASUpdate.Properties;
using JANL;
using System;
using System.Windows.Forms;

namespace FIASUpdate
{
    internal static class Program
    {
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

        private static void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Defaults.Connection = Settings.Default.SQLCS;
        }

        public static string Connection => Settings.Default.SQLCS;
    }
}