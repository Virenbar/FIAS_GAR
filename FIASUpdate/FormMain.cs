using FIASUpdate.Forms;
using System;
using System.Windows.Forms;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region UI Events

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

        private void MI_Search_Click(object sender, EventArgs e)
        {
            var F = new FormAddressSearch();
            F.ShowDialog(this);
        }

        #endregion UI Events
    }
}