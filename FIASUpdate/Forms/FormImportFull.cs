using JANL;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormImportFull : Form
    {
        private CancellationTokenSource CTS;
        private Progress<TaskProgress> TP;

        public FormImportFull()
        {
            InitializeComponent();
        }

        private void AddResult(string table, string status)
        {
            var LVI = LV_Result.Items.Add(table);
            LVI.SubItems.Add(status);
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FIAS_ResultChanged(object sender, ResultAddedEventArgs e) => AddResult(e.Table, e.Status);

        private void SetResult(IReadOnlyDictionary<string, string> Result)
        {
            LV_Result.BeginUpdate();
            LV_Result.Items.Clear();
            foreach (var KV in Result)
            {
                var LVI = LV_Result.Items.Add(KV.Key);
                LVI.SubItems.Add(KV.Value);
            }
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Result.EndUpdate();
        }

        private async Task StartImport()
        {
            CTS = new CancellationTokenSource();
            try
            {
                UIState(false);
                LV_Result.Items.Clear();
                var Options = new ImportOptions
                {
                    OnlyEmpty = CB_OnlyEmpty.Checked,
                    ShrinkDatabase = CB_Shrink.Checked
                };
                SWL.Start();
                using (var FIAS = new DBImportFull(Options))
                {
                    FIAS.ResultAdded += FIAS_ResultChanged;
                    await Task.Run(() => FIAS.Import(TP, CTS.Token));
                    SetResult(FIAS.Result);
                }
            }
            catch (Exception ex) { Msgs.ShowException(ex); }
            finally
            {
                SWL.Stop();
                UIState(true);
                CTS.Dispose();
                CTS = null;
            }
        }

        private void UIState(bool state)
        {
            B_Import.Enabled = state;
            B_Cancel.Enabled = !state;
        }

        #region UI Events

        private void B_Import_Click(object sender, EventArgs e)
        {
            if (CTS is null)
            {
                _ = StartImport();
            }
        }

        private void FormImportFull_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            TP = new Progress<TaskProgress>((T) =>
            {
                if (T.HasStatus) { SL_Status.Text = T.Status; }
                if (T.HasValue)
                {
                    SL_Value.Text = (T.Value + T.Max == 0) ? "" : $"{T.Value:N0}{new string('|', T.Value / 100_000)}";
                }
            });
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CTS?.Cancel();
        }

        #endregion UI Events
    }
}