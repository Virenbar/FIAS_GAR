using FIASUpdate.Forms;
using FIASUpdate.Properties;
using System;
using System.Windows.Forms;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.FIAS_Icon;
        }

        #region UI Events

        private void B_About_Click(object sender, EventArgs e)
        {
            var F = new FormAbout();
            F.ShowDialog(this);
        }

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

        private void B_Operation_Click(object sender, EventArgs e)
        {
            var F = new FormOperation();
            F.ShowDialog(this);
        }

        private void B_Search_Click(object sender, EventArgs e)
        {
            var F = new FormAddressSearch();
#if DEBUG
            F.SearchText = "915b4a80-e4b7-4964-8d46-2320b6e7deb2";
            F.Level = 0;
#endif
            F.ShowDialog(this);
        }

        private void B_Settings_Click(object sender, EventArgs e)
        {
            var F = new FormSettings();
            F.ShowDialog(this);
        }

        #endregion UI Events
    }
}