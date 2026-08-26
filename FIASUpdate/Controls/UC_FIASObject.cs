using System;
using System.Diagnostics;
using System.Windows.Forms;
using FIAS.Core;
using FIAS.Core.Models;
using FIAS.Core.Stores;
using FIASUpdate.Forms;
using FIASUpdate.Properties;
using JANL.Extensions;

namespace FIASUpdate.Controls
{
    public partial class UC_FIASObject : UserControl
    {
        private readonly FIASStore Store = new FIASStore(Settings.Default.SQLConnection);

        public UC_FIASObject()
        {
            InitializeComponent();
        }

        public string Address => TB_Address.Text;

        public FIASDivision Division { get; private set; }

        public string GUID => TB_GUID.Text;

        public void ClearObject()
        {
            TB_GUID.Text = string.Empty;
            TB_Address.Text = string.Empty;
            RefreshUI();
        }

        public void SetObject(FIASRegistryAddress address, FIASDivision division)
        {
            TB_GUID.Text = address.ObjectGUID;
            TB_Address.Text = address.AddressFull;
            Division = division;
            RefreshUI();
        }

        public void SetObject(string guid, string address, FIASDivision division)
        {
            TB_GUID.Text = guid;
            TB_Address.Text = address;
            Division = division;
            RefreshUI();
        }

        private void RefreshUI()
        {
            B_PDF.Enabled = TB_GUID.Text.Length > 0;
            B_Parameters.Enabled = TB_GUID.Text.Length > 0;
            SB_Parameters.Enabled = TB_GUID.Text.Length > 0;
            B_URL.Enabled = TB_GUID.Text.Length > 0;
            B_CopyGUID.Enabled = TB_GUID.Text.Length > 0;
            B_CopyAddress.Enabled = TB_Address.Text.Length > 0;
        }

        #region UI Events

        private void B_CopyAddress_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_Address.Text);
        }

        private void B_CopyGUID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TB_GUID.Text);
        }

        private async void B_Parameters_Click(object sender, EventArgs e)
        {
            B_Parameters.Enabled = false;
            try
            {
                var parameters = await Store.GetObjectParameters(TB_GUID.Text);
                var F = new FormDictionaryView
                {
                    Text = "Параметры объекта",
                    KeyHeader = "Параметр",
                    ValueHeader = "Значение"
                };
                F.SetDictionary(parameters);
                F.ShowDialog(this);
            }
            catch (Exception E) { FindForm().ShowError(E.Message); }
            finally
            {
                B_Parameters.Enabled = true;
            }
        }

        private void B_PDF_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPDFStatementURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void B_URL_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPageURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void MI_PDF_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPDFStatementURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private void MI_URL_Click(object sender, EventArgs e)
        {
            var uri = Store.GetPageURL(TB_GUID.Text, Division);
            var info = new ProcessStartInfo(uri)
            {
                UseShellExecute = true
            };
            Process.Start(info);
        }

        private async void SB_Parameters_Click(object sender, EventArgs e)
        {
            SB_Parameters.Enabled = false;
            try
            {
                var parameters = await Store.GetObjectParameters(TB_GUID.Text);
                var F = new FormDictionaryView
                {
                    Text = "Параметры объекта",
                    KeyHeader = "Параметр",
                    ValueHeader = "Значение"
                };
                F.SetDictionary(parameters);
                F.ShowDialog(this);
            }
            catch (Exception E) { FindForm().ShowError(E.Message); }
            finally
            {
                SB_Parameters.Enabled = true;
            }
        }

        #endregion UI Events
    }
}