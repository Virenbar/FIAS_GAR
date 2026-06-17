using System;
using System.ComponentModel;
using System.Windows.Forms;
using FIAS.Core.Extensions;
using FIASUpdate.Properties;
using JANL;

namespace FIASUpdate
{
    internal static class Program
    {
        private static readonly Settings Settings = Settings.Default;

        private static void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Defaults.Connection = Settings.SQLConnection;
            FIASProperties.Refresh();
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
            SQLExtensions.DefaultConnection = Settings.SQLConnection;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}