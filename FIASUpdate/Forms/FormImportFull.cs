using FIASUpdate.Models;
using JANL.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormImportFull : Form
    {
        private CancellationTokenSource CTS;

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

        private void RefreshUI()
        {
            B_Import.Enabled = CTS == null;
            B_Cancel.Enabled = CTS != null;
        }

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
            RefreshUI();
            TS_Stopwatch.Start();
            try
            {
                LV_Result.Items.Clear();
                var Options = new ImportFullOptions
                {
                    OnlyEmpty = CB_OnlyEmpty.Checked,
                    ShrinkDatabase = CB_Shrink.Checked
                };
                using (var FIAS = new DBImportFull(Options))
                {
                    FIAS.ResultAdded += FIAS_ResultChanged;
                    await Task.Run(() => FIAS.Import(TS_Progress.Progress, CTS.Token));
                    SetResult(FIAS.Result);
                }
            }
            catch (Exception ex) { this.ShowException(ex); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                RefreshUI();
                TS_Stopwatch.Stop();
            }
        }

        #region UI Events

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CTS.Cancel();
            B_Cancel.Enabled = false;
        }

        private void B_Import_Click(object sender, EventArgs e)
        {
            _ = StartImport();
        }

        private void FormImportFull_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(FIASProperties.GAR_Full);
            Process.Start(FIASProperties.GAR_Full);
        }

        #endregion UI Events
    }
}