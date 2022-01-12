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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            Init();
        }

        private static void Init()
        {
            JANL.SQL.Defaults.DefaultConnection = FIASManager.DBString;
        }
    }
}