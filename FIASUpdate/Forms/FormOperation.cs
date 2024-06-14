using FIAS.Core;
using FIAS.Core.Stores;
using FIASUpdate.Properties;
using JANL.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormOperation : Form
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);
        private CancellationTokenSource CTS;

        public FormOperation()
        {
            InitializeComponent();
        }

        private async Task Execute()
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            TS_Stopwatch.Start();
            try
            {
                if (CB_Update.Checked)
                {
                    if (RB_mun.Checked || RB_mun_adm.Checked)
                    {
                        await RefreshRegistry(FIASDivision.mun, CTS.Token);
                        await Task.Delay(500);
                    }
                    if (RB_adm.Checked || RB_mun_adm.Checked)
                    {
                        await RefreshRegistry(FIASDivision.adm, CTS.Token);
                        await Task.Delay(500);
                    }
                }
                if (CB_Shrink.Checked)
                {
                    await Shrink(CTS.Token);
                }
            }
            catch (Exception e) { this.ShowException(e); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                TS_Stopwatch.Stop();
                RefreshUI();
            }
        }

        private async Task RefreshRegistry(FIASDivision division, CancellationToken token)
        {
            TS_Progress.Status = $"Обновление реестра ({division})";
            await Store.RefreshRegistry(division, token);
            TS_Progress.Status = $"Реестр обновлён ({division})";
        }

        private void RefreshUI()
        {
            RB_mun.Enabled = CB_Update.Checked;
            RB_mun_adm.Enabled = CB_Update.Checked;
            RB_adm.Enabled = CB_Update.Checked;
            tableLayoutPanel1.Enabled = CTS == null;
            B_Run.Enabled = CTS == null;
            B_Cancel.Enabled = CTS != null;
        }

        private async Task Shrink(CancellationToken token)
        {
            using (var DB = new DBClient())
            {
                var Size = DB.Size;
                TS_Progress.Status = $"Сжатие БД ({Size:N2} МБ)";
                await Task.Delay(500, token);
                await Task.Run(DB.Shrink, token);
                TS_Progress.Status = $"БД сжата ({Size:N2} МБ -> {DB.Size:N2} МБ)";
            }
        }

        #region UI Events

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CTS.Cancel();
            B_Cancel.Enabled = false;
        }

        private void B_Run_Click(object sender, EventArgs e)
        {
            _ = Execute();
        }

        private void CB_Update_CheckedChanged(object sender, EventArgs e) => RefreshUI();

        private void FormOperation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CTS != null)
            {
                e.Cancel = true;
                this.ShowWarning("Отмените выполнение, чтобы закрыть окно.");
            }
        }

        private void FormOperation_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            RefreshUI();
        }

        #endregion UI Events
    }
}