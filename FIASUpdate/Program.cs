using FIASUpdate.Properties;
using JANL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FIASUpdate
{
    internal static class Program
    {
        private static readonly Settings Settings = Settings.Default;

        private static void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Defaults.Connection = Settings.SQLConnection;
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (!Settings.Upgraded)
            {
                Settings.Upgrade();
                Settings.Upgraded = true;
                Settings.Save();
            }
            Settings.PropertyChanged += Default_PropertyChanged;
            Settings.Reload();
            Defaults.Connection = Settings.SQLConnection;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}