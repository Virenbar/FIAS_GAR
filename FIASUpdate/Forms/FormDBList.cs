using FIASUpdate.Models;
using FIASUpdate.Properties;
using JANL.Extensions;
using Microsoft.Data.ConnectionUI;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormDBList : Form
    {
        private static readonly Settings Settings = Settings.Default;
        private DBStringItem Current;

        public FormDBList()
        {
            InitializeComponent();
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
            foreach (var DB in Settings.SQLConnections)
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
            var connection = new SqlConnectionStringBuilder(Current.Connection)
            {
                ApplicationName = "FIAS Update"
            };
            Settings.SQLConnection = connection.ToString();
            Settings.Save();
            Close();
        }

        private void FormDBList_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
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
                    Settings.SQLConnections.Add(D.ConnectionString);
                    Settings.Save();
                }
            }
            RefreshList();
        }

        private void MI_Delete_Click(object sender, EventArgs e)
        {
            if (this.AskYesNo($"Удалить {Current.Server}({Current.Database})?") == DialogResult.Yes)
            {
                Settings.SQLConnections.Remove(Current.Connection);
                Settings.Save();
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
                    Settings.SQLConnections.Remove(Current.Connection);
                    Settings.SQLConnections.Add(D.ConnectionString);
                    Settings.Save();
                }
            }
            RefreshList();
        }

        #endregion UI Events
    }
}