using FIAS.Core.Models;
using FIAS.Core.Stores;
using FIASUpdate.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace FIASUpdate.Controls
{
    public partial class UC_Database : UserControl
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);

        public UC_Database()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            var Tables = Store.TablesInfo();
            LV_Tables.BeginUpdate();
            LV_Tables.Items.Clear();
            foreach (var T in Tables)
            {
                var LVI = new ListViewItem(new[] { $"{T.Name}", $"{T.RowCount:N0}", $"{T.TotalMB:N2} МБ", $"{T.LastImport:yyyy.MM.dd}" }) { Tag = T, Checked = T.CanImport };
                LV_Tables.Items.Add(LVI);
            }
            LV_Tables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Tables.EndUpdate();
            TB_Version.Text = $"{Store.GetVersion():yyyy.MM.dd}";
            TB_Subject.Text = string.Join(" ", Store.GetSubjects());
        }

        private void SaveData()
        {
            foreach (ListViewItem item in LV_Tables.Items)
            {
                var Table = (FIASTableInfo)item.Tag;
                Store.SetCanImport(Table.Name, item.Checked);
            }
            RefreshData();
        }

        #region UIEvents

        private void B_Refresh_Click(object sender, EventArgs e) => RefreshData();

        private void B_Save_Click(object sender, EventArgs e)
        {
            Settings.Save();
            SaveData();
        }

        private void B_SQLConnection_Click(object sender, EventArgs e)
        {
            using (var F = new FormDBList())
            {
                F.ShowDialog(this);
                Store.Connection = Settings.SQLConnection; // Program.Connection;
            }
        }

        private void B_XMLPath_Click(object sender, EventArgs e)
        {
            using (var F = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                DefaultDirectory = Settings.XMLPath // Program.XMLPath
            })
            {
                if (F.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Settings.XMLPath = F.FileName;
                    Settings.Save();
                }
            }
        }

        private void UC_Database_Load(object sender, EventArgs e)
        {
            LV_Tables.Items.Clear();
        }

        #endregion UIEvents
    }
}