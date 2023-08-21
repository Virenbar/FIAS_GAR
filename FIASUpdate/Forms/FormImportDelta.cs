using FIAS.Core.API;
using FIAS.Core.Stores;
using FIASUpdate.Models;
using FIASUpdate.Properties;
using JANL;
using JANL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormImportDelta : Form
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);
        private List<FIASArchive> Archives;
        private CancellationTokenSource CTS;
        private List<string> Subjects;
        private Progress<TaskProgress> TP;
        private DateTime Version;

        public FormImportDelta()
        {
            InitializeComponent();
        }

        private async Task Download()
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            try
            {
                var Count = 0;
                var archives = Archives.Where(A => !A.IsExsists()).ToList();
                SL_Status.Text = "Скачивание архивов";
                SL_Value.Text = $@"{Count}\{archives.Count}";
                var PP = new Progress<int>((count) =>
                {
                    Count += count;
                    SL_Value.Text = $@"{Count}\{archives.Count}";
                    RefreshList();
                });
                using (var AD = new ArchiveDownloader(archives))
                {
                    await AD.Download(PP, CTS.Token);
                }
                SL_Status.Text = "Скачивание завершено";
            }
            catch (TaskCanceledException)
            {
                SL_Status.Text = "Скачивание отменено";
                SL_Value.Text = "-";
            }
            catch (Exception e) { this.ShowException(e); }
            CTS.Dispose();
            CTS = null;

            RefreshUI();
        }

        private async Task RefreshDatabase()
        {
            var version = Store.GetVersion();
            var subjects = Store.GetSubjects();
            if (!version.HasValue)
            {
                this.ShowError("В свойствах БД не указана версия ФИАС. Обновление невозможно.");
                return;
            }
            if (subjects.Count == 0)
            {
                this.ShowError("В свойствах БД не указан список субъектов РФ. Обновление невозможно.");
                return;
            }
            Version = version.Value;
            Subjects = subjects;
            TB_Version.Text = $"{Version:yyyy.MM.dd}";
            TB_Subject.Text = string.Join(" ", Subjects);

            SL_Status.Text = "Получение списка архивов";
            using (var client = new FIASClient())
            {
                var info = await client.GetAllDownloadFileInfo(Version);
                Archives = info.Select(I => new FIASArchive(I)).ToList();
            }
            SL_Status.Text = "-";
            RefreshList();
            RefreshUI();
        }

        private void RefreshList()
        {
            LV_Archives.BeginUpdate();
            LV_Archives.Items.Clear();
            LV_Archives.Items.AddRange(Archives.Select(A => new FIASArchiveItem(A)).ToArray());
            LV_Archives.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Archives.EndUpdate();
        }

        private void RefreshUI()
        {
            B_Download.Enabled = CTS == null && Archives.Any(A => !A.IsExsists());
            B_Cancel.Enabled = CTS != null;
        }

        #region UI Events

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CTS.Cancel();
            B_Cancel.Enabled = false;
        }

        private void B_Download_Click(object sender, EventArgs e)
        {
            _ = Download();
        }

        private void FormImportDelta_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            TP = new Progress<TaskProgress>((T) =>
            {
                if (T.HasStatus) { SL_Status.Text = T.Status; }
                if (T.HasValue) { SL_Value.Text = (T.Value + T.Max == 0) ? "" : $"{T.Value:N0}"; }
            });
            _ = RefreshDatabase();
        }

        #endregion UI Events
    }
}