using FIASUpdate.Models;
using FIASUpdate.Properties;
using JANL;
using Microsoft.Data.ConnectionUI;
using System;
using System.Windows.Forms;

namespace FIASUpdate
{
    public partial class FormDBList : Form
    {
        private DBStringItem Current;

        public FormDBList()
        {
            InitializeComponent();
            Icon = Resources.FNS;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) { return; }
            RefreshList();
        }

        private void RefreshList()
        {
            LV_DB.BeginUpdate();
            LV_DB.Items.Clear();
            foreach (var DB in Settings.Default.SQLConnections)
            {
                LV_DB.Items.Add(new DBStringItem(DB));
            }
            LV_DB.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_DB.EndUpdate();
            RefreshUI();
        }

        private void RefreshUI()
        {
            var State = Current != null;
            B_Select.Enabled = State;
            MI_Edit.Enabled = State;
            MI_Delete.Enabled = State;
        }

        #region UI Events

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_Select_Click(object sender, EventArgs e)
        {
            Settings.Default.SQLCS = Current.Connection;
            Settings.Default.Save();
            Close();
        }

        private void LV_DB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Current = LV_DB.SelectedItems.Count > 0 ? (DBStringItem)LV_DB.SelectedItems[0] : null;
            RefreshUI();
        }

        private void MI_Add_Click(object sender, EventArgs e)
        {
            using (var D = new DataConnectionDialog())
            {
                DataSource.AddStandardDataSources(D);
                D.SelectedDataSource = DataSource.SqlDataSource;
                D.SelectedDataProvider = DataProvider.SqlDataProvider;
                if (DataConnectionDialog.Show(D, this) == DialogResult.OK)
                {
                    Settings.Default.SQLConnections.Add(D.ConnectionString);
                    Settings.Default.Save();
                }
            }
            RefreshList();
        }

        private void MI_Delete_Click(object sender, EventArgs e)
        {
            if (Msgs.AskYesNo($"Удалить {Current.Server}({Current.Database})?") == DialogResult.Yes)
            {
                Settings.Default.SQLConnections.Remove(Current.Connection);
                Settings.Default.Save();
            }
            RefreshList();
        }

        private void MI_Edit_Click(object sender, EventArgs e)
        {
            using (var D = new DataConnectionDialog())
            {
                DataSource.AddStandardDataSources(D);
                D.SelectedDataSource = DataSource.SqlDataSource;
                D.SelectedDataProvider = DataProvider.SqlDataProvider;
                D.ConnectionString = Current.Connection;
                if (DataConnectionDialog.Show(D, this) == DialogResult.OK)
                {
                    Settings.Default.SQLConnections.Remove(Current.Connection);
                    Settings.Default.SQLConnections.Add(D.ConnectionString);
                    Settings.Default.Save();
                }
            }
            RefreshList();
        }

        #endregion UI Events
    }
}