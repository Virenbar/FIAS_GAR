using FIAS.Core.Stores;
using FIASUpdate.Models;
using FIASUpdate.Properties;
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
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);
        private FIASArchiveFull Archive;
        private CancellationTokenSource CTS;
        private List<string> Subjects;
        private DateTime Version;

        public FormImportFull()
        {
            InitializeComponent();
        }

        private void AddResult(TableImportResult result)
        {
            var LVI = LV_Result.Items.Add(result.Table);
            LVI.SubItems.Add(result.Status);
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FIAS_ResultChanged(object sender, ResultAddedEventArgs e) => AddResult(e.Result);

        private void RefreshDatabase()
        {
            var version = Store.GetVersion();
            var subjects = Store.GetSubjects();
            if (subjects.Count == 0)
            {
                this.ShowError("В свойствах БД не указан список субъектов РФ. Импорт невозможно.");
                return;
            }
            Version = version.Value;
            Subjects = subjects;
            Info.Version = Version;
            Info.Subjects = Subjects;

            RefreshUI();
        }

        private void RefreshUI()
        {
            B_Import.Enabled = CTS == null && Archive != null && Archive.Exsists;
            B_Cancel.Enabled = CTS != null;
        }

        private void SetResult(IReadOnlyList<TableImportResult> Result)
        {
            LV_Result.BeginUpdate();
            LV_Result.Items.Clear();
            foreach (var R in Result)
            {
                var LVI = LV_Result.Items.Add(R.Table);
                LVI.SubItems.Add(R.Status);
            }
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Result.EndUpdate();
        }

        private async Task StartTask(Func<CancellationToken, Task> task)
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            TS_Stopwatch.Start();
            try
            {
                await task(CTS.Token);
            }
            catch (Exception ex) { this.ShowException(ex); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                TS_Stopwatch.Stop();
                RefreshUI();
            }
        }

        private async Task TaskImport(CancellationToken token)
        {
            try
            {
                LV_Result.Items.Clear();
                using (var FIAS = new DBImportFull(Archive)
                {
                    Subjects = Subjects,
                    OnlyEmpty = CB_OnlyEmpty.Checked
                })
                {
                    FIAS.ResultAdded += FIAS_ResultChanged;
                    await Task.Run(() => FIAS.Import(TS_Progress.Progress, CTS.Token));
                    SetResult(FIAS.Result);
                }
                TS_Progress.Status = "Импорт завершён";
                FLP_Action.Enabled = false;
            }
            catch (OperationCanceledException)
            {
                TS_Progress.Status = "Импорт отменён";
                TS_Progress.Value = "-";
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
            _ = StartTask(TaskImport);
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(FIASProperties.GAR_Full);
            Process.Start(FIASProperties.GAR_Full);
        }

        private void B_Select_Click(object sender, EventArgs e)
        {
            TB_Archive.SelectFile();
        }

        private void FormImportFull_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CTS != null)
            {
                e.Cancel = true;
                this.ShowWarning("Отмените выполнение, чтобы закрыть окно.");
            }
        }

        private void FormImportFull_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            LV_Result.Items.Clear();
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            RefreshDatabase();
        }

        private void TB_Archive_TextChanged(object sender, EventArgs e)
        {
            // TB_Archive.Text
            Archive = new FIASArchiveFull(TB_Archive.Text);
            Archive.ExtractVersion();
            TB_Version.Text = Archive.Date == default ? "" : $"{Archive.Date:yyyy.MM.dd}";
            RefreshUI();
        }

        #endregion UI Events
    }
}