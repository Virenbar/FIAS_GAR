using FIAS.Core.Stores;
using FIASUpdate.Controls;
using FIASUpdate.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormSettings : Form
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);

        public FormSettings()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            var Tables = Store.TablesInfo();
            LV_Tables.BeginUpdate();
            LV_Tables.Items.Clear();
            LV_Tables.Items.AddRange(Tables.Select(T => new TableLVI(T)).ToArray());
            LV_Tables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Tables.EndUpdate();
            Info.Version = Store.GetVersion();
            Info.Subjects = Store.GetSubjects();
        }

        private void SaveData()
        {
            foreach (TableLVI item in LV_Tables.Items)
            {
                Store.SetCanImport(item.Name, item.Checked);
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
                Store.Connection = Settings.SQLConnection;
            }
        }

        private void B_XMLPath_Click(object sender, EventArgs e)
        {
            using (var F = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                DefaultDirectory = Settings.XMLPath
            })
            {
                if (F.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Settings.XMLPath = F.FileName;
                    Settings.Save();
                }
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            LV_Tables.Items.Clear();
        }

        #endregion UIEvents
    }
}