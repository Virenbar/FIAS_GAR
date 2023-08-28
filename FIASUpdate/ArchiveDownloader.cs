using FIASUpdate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FIASUpdate
{
    internal class ArchiveDownloader : IDisposable
    {
        private readonly List<FIASArchive> Archives;
        private readonly HttpClient Client;
        private readonly SemaphoreSlim Semaphore;

        /// <summary>
        ///
        /// </summary>
        /// <param name="archives">Список архивов</param>
        public ArchiveDownloader(List<FIASArchive> archives) : this(archives, 2) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="archives">Список архивов</param>
        /// <param name="threads">Количество "потоков" для скачивания</param>
        public ArchiveDownloader(List<FIASArchive> archives, int threads)
        {
            Archives = archives;
            Client = new HttpClient();
            Semaphore = new SemaphoreSlim(threads);
        }

        public async Task Download(IProgress<int> IP = default, CancellationToken token = default)
        {
            var Tasks = Archives.Select(async (archive) =>
            {
                await TryDownloadArchive(archive, token);
                IP.Report(1);
            });
            await Task.WhenAll(Tasks);
        }

        private async Task<string> TryDownloadArchive(FIASArchive archive, CancellationToken token)
        {
            var LocalFile = new FileInfo(archive.ArchivePath);
            try
            {
                await Semaphore.WaitAsync();
                token.ThrowIfCancellationRequested();
                // Считать только заголовок
                using (var Responce = await Client.GetAsync(archive.URLDelta, HttpCompletionOption.ResponseHeadersRead, token))
                {
                    Responce.EnsureSuccessStatusCode();
                    Directory.CreateDirectory(LocalFile.DirectoryName);
                    // А содержимое записать прямо в файл
                    using (var FS = new FileStream(LocalFile.FullName, FileMode.Create))
                    using (var RS = await Responce.Content.ReadAsStreamAsync())
                        await RS.CopyToAsync(FS);
                }
                return LocalFile.FullName;
            }
            finally
            {
                Semaphore.Release();
            }
        }

        #region IDisposable

        public void Dispose()
        {
            Client.Dispose();
            Semaphore.Dispose();
        }

        #endregion IDisposable
    }
}