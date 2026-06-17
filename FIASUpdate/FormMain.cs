using System;
using System.Windows.Forms;
using FIASUpdate.Forms;
using FIASUpdate.Properties;

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

        #endregion Service

        #endregion UI Events
    }
}