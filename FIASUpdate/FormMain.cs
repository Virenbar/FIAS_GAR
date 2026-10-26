using System;
using System.Linq;
using System.Windows.Forms;
using FIAS.Core.Stores;
using FIASUpdate.Forms;
using FIASUpdate.Properties;
using JANL.Extensions;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.FIAS_Icon;
            RefreshUI();
        }

        private void RefreshUI()
        {
            L_Database.Text = string.IsNullOrEmpty(FIASProperties.DatabaseName)
                ? $"БД: Не выбрана"
                : $@"БД: {FIASProperties.ServerName}\{FIASProperties.DatabaseName}";
        }

        #region UI Events

        private void B_About_Click(object sender, EventArgs e)
        {
            var F = new FormAbout();
            F.ShowDialog(this);
        }

        private void B_Settings_Click(object sender, EventArgs e)
        {
            var F = new FormSettings();
            F.ShowDialog(this);
            RefreshUI();
        }

        #region Import

        private void B_ImportDelta_Click(object sender, EventArgs e)
        {
            var F = new FormImportDelta();
            F.ShowDialog(this);
        }

        private void B_ImportFull_Click(object sender, EventArgs e)
        {
            var F = new FormImportFull();
            F.ShowDialog(this);
        }

        #endregion Import

        #region Service

        private void B_Explorer_Click(object sender, EventArgs e)
        {
            using (var F = new FormAddressExplorer())
            {
#if DEBUG
                F.FilterText = "екат уральск 5 64";
                F.RootGUID = "92b30014-4d52-4e2e-892d-928142b924bf";
#endif
                F.ShowDialog(this);
            }
        }

        private void B_Operation_Click(object sender, EventArgs e)
        {
            var F = new FormOperation();
            F.ShowDialog(this);
        }

        private void B_Search_Click(object sender, EventArgs e)
        {
            using (var F = new FormAddressSearch())
            {
#if DEBUG
                F.SearchText = "915b4a80-e4b7-4964-8d46-2320b6e7deb2";
                F.Level = 0;
#endif
                F.ShowDialog(this);
            }
        }

        private async void B_Statistics_Click(object sender, EventArgs e)
        {
            B_Statistics.Enabled = false;
            try
            {
                var store = new FIASStore(Settings.Default.SQLConnection);
                var statistics = await store.Statistics();
                var date = statistics.First();

                using (var F = new FormDictionaryView
                {
                    Text = $"Информация о БД ({date.Key}: {date.Value})",
                    KeyHeader = "Уровень",
                    ValueHeader = "Количество"
                })
                {
                    F.SetDictionary(statistics.Skip(1));
                    F.ShowDialog(this);
                }
            }
            catch (Exception E) { this.ShowError(E.Message); }
            finally
            {
                B_Statistics.Enabled = true;
            }
        }

        #endregion Service

        #endregion UI Events

    }
}