using FIAS.Core.API;
using FIAS.Core.Stores;
using FIASUpdate.Models;
using FIASUpdate.Properties;
using JANL.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate.Forms
{
    public partial class FormImportDelta : Form
    {
        private static readonly FIASClient Client = new FIASClient();
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASDatabaseStore Store = new FIASDatabaseStore(Settings.SQLConnection);
        private List<FIASArchive> Archives;
        private CancellationTokenSource CTS;
        private List<string> Subjects;
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
            Info.Version = Version;
            Info.Subjects = Subjects;

            TS_Progress.Status = "Получение списка архивов";
            try
            {
                var info = await Client.GetAllDownloadFileInfo(Version);
                // Бывают выгрузки без ссылок на архивы ГАР.
                // Если отсутствуют обе,то пропустить такую выгрузку, например от 24.11.2023.
                Archives = info.Where(I => !(string.IsNullOrEmpty(I.GarXMLFullURL) && string.IsNullOrEmpty(I.GarXMLDeltaURL)))
                    .Select(I => new FIASArchive(I))
                    .ToList();
            }
            catch (SocketException ex)
            {
                this.ShowError(ex, "Не удалось получить список архивов");
                return;
            }

            if (Archives.Count == 0)
            {
                TS_Progress.Status = "Обновление не требуется";
                return;
            }

            if (Archives.Any(A => string.IsNullOrEmpty(A.URLDelta)))
            {
                this.ShowError("У некоторых архивов отсутствует ссылка на скачивание. Обновление невозможно.");
                return;
            }

            TS_Progress.Clear();
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
            LV_Archives.EndUpdate();
        }

        private void RefreshUI()
        {
            B_Download.Enabled = CTS == null && Archives.Any(A => !A.Exsists);
            B_Import.Enabled = CTS == null && Archives.Count > 0 && Archives.All(A => A.Exsists);
            B_Cancel.Enabled = CTS != null;
        }

        private IEnumerable<FIASArchiveItem> ListItems => LV_Archives.Items.Cast<FIASArchiveItem>();

        private async Task TaskDownload()
        {
            CTS = new CancellationTokenSource();
            RefreshUI();
            try
            {
                var count = 0;
                var items = ListItems.Where(A => !A.Archive.Exsists).ToList();

                TS_Progress.Status = "Скачивание архивов";
                TS_Progress.Value = $@"{count}/{items.Count}";
                using (var AD = new ArchiveDownloader())
                {
                    var tasks = items.Select(async A =>
                    {
                        await AD.Download(A.Archive);
                        A.Refresh();
                        count++;
                        TS_Progress.Value = $@"{count}/{items.Count}";
                    });
                    await Task.WhenAll(tasks);
                }
                TS_Progress.Status = "Скачивание завершено";
            }
            catch (OperationCanceledException)
            {
                TS_Progress.Status = "Скачивание отменено";
                TS_Progress.Value = "-";
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
                var items = ListItems.OrderBy(I => I.Archive.Date);
                foreach (var item in items)
                {
                    item.State = "Импорт";
                    var Options = new ImportDeltaOptions
                    {
                        Subjects = Subjects
                    };
                    using (var FIAS = new DBImportDelta(item.Archive, Options))
                    {
                        await Task.Run(() => FIAS.Import(TS_Progress.Progress, CTS.Token));
                    }
                    item.State = "Импортирован";
                }
                TS_Progress.Status = "Импорт завершён";
                FLP_Action.Enabled = false;
            }
            catch (OperationCanceledException)
            {
                TS_Progress.Status = "Импорт отменён";
                TS_Progress.Value = "-";
            }
            catch (Exception e) { this.ShowException(e); }
            finally
            {
                CTS.Dispose();
                CTS = null;
                RefreshUI();
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

        private void B_Open_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(FIASProperties.GAR_Delta);
            Process.Start(FIASProperties.GAR_Delta);
        }

        private void FormImportDelta_Load(object sender, EventArgs e)
        {
            Icon = Owner.Icon;
            _ = RefreshDatabase();
        }

        #endregion UI Events
    }
}