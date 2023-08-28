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
            if (Archives.Count == 0) { return; }
            LV_Archives.BeginUpdate();
            LV_Archives.Items.Clear();
            LV_Archives.Items.AddRange(Archives.Select(A => new FIASArchiveItem(A)).ToArray());
            LV_Archives.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Archives.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Archives.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Archives.EndUpdate();
        }

        private void RefreshUI()
        {
            B_Download.Enabled = CTS == null && Archives.Any(A => !A.Exsists);
            B_Import.Enabled = CTS == null && Archives.All(A => A.Exsists);
            B_Cancel.Enabled = CTS != null;
        }

        private async Task TaskDownload()
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            try
            {
                var Count = 0;
                var archives = Archives.Where(A => !A.Exsists).ToList();
                SL_Status.Text = "Скачивание архивов";
                SL_Value.Text = $@"{Count}/{archives.Count}";
                var PP = new Progress<int>((count) =>
                {
                    Count += count;
                    SL_Value.Text = $@"{Count}/{archives.Count}";
                    // TODO: Refresh only one
                    RefreshList();
                });
                using (var AD = new ArchiveDownloader(archives))
                {
                    await AD.Download(PP, CTS.Token);
                }
                SL_Status.Text = "Скачивание завершено";
            }
            catch (OperationCanceledException)
            {
                SL_Status.Text = "Скачивание отменено";
                SL_Value.Text = "-";
            }
            catch (Exception e) { this.ShowException(e); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                RefreshList();
                RefreshUI();
            }
        }

        private async Task TaskImport()
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            try
            {
                var items = LV_Archives.Items.Cast<FIASArchiveItem>().OrderBy(I => I.Archive.Date);
                foreach (var item in items)
                {
                    var Options = new ImportDeltaOptions
                    {
                        Subjects = Subjects
                        //ShrinkDatabase = CB_Shrink.Checked
                    };
                    //SWL.Start();
                    item.State = "Импортирование";

                    using (var FIAS = new DBImportDelta(item.Archive, Options))
                    {
                        await Task.Run(() => FIAS.Import(TP, CTS.Token));
                    }
                    item.State = "Импортирован";
                }
                SL_Status.Text = "Импорт завершён";
            }
            catch (OperationCanceledException)
            {
                SL_Status.Text = "Импорт отменён";
                SL_Value.Text = "-";
            }
            catch (Exception e) { this.ShowException(e); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                RefreshUI();
                B_Import.Enabled = false;
            }
        }

        #region UI Events

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            CTS.Cancel();
            B_Cancel.Enabled = false;
        }

        private void B_Download_Click(object sender, EventArgs e)
        {
            _ = TaskDownload();
        }

        private void B_Import_Click(object sender, EventArgs e)
        {
            _ = TaskImport();
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