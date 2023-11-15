using FIASUpdate.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FIASUpdate
{
    internal class ArchiveDownloader : IDisposable
    {
        private readonly HttpClient Client;
        private readonly SemaphoreSlim Semaphore;

        /// <summary>
        ///
        /// </summary>
        public ArchiveDownloader() : this(2) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="threads">Количество "потоков" для скачивания</param>
        public ArchiveDownloader(int threads)
        {
            Client = new HttpClient();
            Semaphore = new SemaphoreSlim(threads);
        }

        public async Task Download(FIASArchive archive, CancellationToken token = default)
        {
            await TryDownloadArchive(archive, token);
        }

        private async Task TryDownloadArchive(FIASArchive archive, CancellationToken token)
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