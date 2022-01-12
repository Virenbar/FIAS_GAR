using JANL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIASUpdate.API;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        private Progress<TaskProgress> TP;
        private FIASClient Client;

        public FormMain()
        {
            InitializeComponent();
        }

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
                var Options = new ImportOptions()
                {
                    Skip = CB_OnlyEmpty.Checked,
                    Shrink = CB_Shrink.Checked
                };
                SWL.Start();
                using (var FIAS = new FIAS_GAR(TP))
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

        private async void FormMain_Load(object sender, EventArgs e)
        {
            Client = new FIASClient();
            var ttt = await Client.GetAllDownloadFileInfo(new DateTime(2021, 11, 3));

            TP = new Progress<TaskProgress>((T) =>
            {
                if (T.HasStatus) { SL_Status.Text = T.Status; }
                if (T.HasValue)
                {
                    if (T.Value + T.Max == 0)
                    {
                        SL_Value.Text = "";
                        return;
                    }
                    SL_Value.Text = T.Value.ToString("N0");
                    SL_Value.Text += " " + new string('|', T.Value / 100_000);
                }
            });
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
    }
}