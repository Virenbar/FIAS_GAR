using FIAS.Core.Extensions;
using FIAS.Core.Models;
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
        /// Создает клиент для скачивания архивов
        /// </summary>
        public ArchiveDownloader() : this(4) { }

        /// <summary>
        /// Создает клиент для скачивания архивов
        /// </summary>
        /// <param name="threads">Количество "потоков" для скачивания</param>
        public ArchiveDownloader(int threads)
        {
            Client = new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = threads });
            Semaphore = new SemaphoreSlim(threads);
        }

        public async Task Download(FIASArchive archive, CancellationToken token = default)
        {
            var LocalFile = new FileInfo(archive.ArchivePath);
            try
            {
                await Semaphore.WaitAsync().ConfigureAwait(false);
                token.ThrowIfCancellationRequested();
                Directory.CreateDirectory(LocalFile.DirectoryName);
                using (var FS = new FileStream(LocalFile.FullName, FileMode.Create))
                    await Client.DownloadAsync(archive.URLDelta, FS, token).ConfigureAwait(false);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        public async Task Download(FIASArchive archive, IProgress<float> progress, CancellationToken token = default)
        {
            var LocalFile = new FileInfo(archive.ArchivePath);
            try
            {
                await Semaphore.WaitAsync().ConfigureAwait(false);
                token.ThrowIfCancellationRequested();
                Directory.CreateDirectory(LocalFile.DirectoryName);
                using (var FS = new FileStream(LocalFile.FullName, FileMode.Create))
                    await Client.DownloadAsync(archive.URLDelta, FS, progress, token).ConfigureAwait(false);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        public async Task Download(FIASArchive archive, IProgress<DownloadState> progress, CancellationToken token = default)
        {
            var LocalFile = new FileInfo(archive.ArchivePath);
            try
            {
                await Semaphore.WaitAsync().ConfigureAwait(false);
                token.ThrowIfCancellationRequested();
                Directory.CreateDirectory(LocalFile.DirectoryName);
                using (var FS = new FileStream(LocalFile.FullName, FileMode.Create))
                    await Client.DownloadAsync(archive.URLDelta, FS, progress, token).ConfigureAwait(false);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        /// <summary>
        /// Получить размер архива
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<long?> GetArhchiveSize(FIASArchive archive, CancellationToken token = default)
        {
            try
            {
                await Semaphore.WaitAsync().ConfigureAwait(false);
                token.ThrowIfCancellationRequested();
                return await Client.GetFileSizeAsync(archive.URLDelta).ConfigureAwait(false);
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