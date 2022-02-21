using FIASUpdate.API;
using JANL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using FIASUpdate.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        private Progress<TaskProgress> TP;

        public FormMain() => InitializeComponent();

        private void AddResult(string table, string status)
        {
            var LVI = LV_Result.Items.Add(table);
            LVI.SubItems.Add(status);
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private async void B_Import_Click(object sender, EventArgs e)
        {
            try
            {
                B_Import.Enabled = false;
                LV_Result.Items.Clear();
                var Options = new ImportOptions
                {
                    Skip = CB_OnlyEmpty.Checked,
                    Shrink = CB_Shrink.Checked
                };
                SWL.Start();
                using (var FIAS = new DBImport(TP))
                {
                    FIAS.ResultAdded += FIAS_ResultChanged;
                    await Task.Run(() => FIAS.Import(Options));
                    SetResult(FIAS.Result);
                }
            }
            catch (Exception ex) { Msgs.ShowException(ex); }
            finally
            {
                SWL.Stop();
                B_Import.Enabled = true;
            }
        }

        private void CB_Drop_CheckedChanged(object sender, EventArgs e)
        {
            CB_DropConfirm.Visible = CB_Drop.Checked;
            if (!CB_Drop.Checked) { CB_DropConfirm.Checked = false; }
        }

        private void CB_DropConfirm_CheckedChanged(object sender, EventArgs e) => L_DropWarning.Visible = CB_DropConfirm.Checked;

        private void FIAS_ResultChanged(object sender, ResultAddedEventArgs e) => AddResult(e.Table, e.Status);

        private void FormMain_Load(object sender, EventArgs e)
        {
            TP = new Progress<TaskProgress>((T) =>
            {
                if (T.HasStatus) { SL_Status.Text = T.Status; }
                if (T.HasValue)
                {
                    SL_Value.Text = (T.Value + T.Max == 0) ? "" : $"{T.Value:N0}{new string('|', T.Value / 100_000)}";
                }
            });
        }

        private async void GetFiles()
        {
            using (var Client = new FIASClient())
            {
                var Files = await Client.GetAllDownloadFileInfo(new DateTime(2022, 1, 4));
                Console.WriteLine(Files.First().GarXMLDeltaURL);
            }
        }

        private void SetResult(IReadOnlyDictionary<string, string> Result)
        {
            LV_Result.Items.Clear();
            foreach (var KV in Result)
            {
                var LVI = LV_Result.Items.Add(KV.Key);
                LVI.SubItems.Add(KV.Value);
            }
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        #region UI Events

        private void B_SQLConnection_Click(object sender, EventArgs e)
        {
            using (var D = new DataConnectionDialog())
            {
                DataSource.AddStandardDataSources(D);
                //D.DataSources.Add(DataSource.SqlDataSource);
                D.SelectedDataSource = DataSource.SqlDataSource;
                D.SelectedDataProvider = DataProvider.SqlDataProvider;
                D.ConnectionString = FIASManager.DBString;
                if (DataConnectionDialog.Show(D) == DialogResult.OK)
                {
                    Settings.Default.SQLCS = D.ConnectionString;
                    Settings.Default.Save();
                }
            }
        }

        private void B_XMLPath_Click(object sender, EventArgs e)
        {
            using (var F = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                DefaultDirectory = FIASManager.Root
            })
            {
                if (F.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Settings.Default.XMLPath = F.FileName;
                    Settings.Default.Save();
                }
            }
        }

        #endregion UI Events

        private void B_Search_Click(object sender, EventArgs e)
        {
            var F = new FormAddressSearch();
            F.ShowDialog(this);
        }
    }
}