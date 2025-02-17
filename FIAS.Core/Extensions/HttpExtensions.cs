using FIAS.Core.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FIAS.Core.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Асинхронно скачать файл
        /// </summary>
        public static Task DownloadAsync(this HttpClient client, string requestUri, Stream destination) => DownloadAsync(client, requestUri, destination, default(CancellationToken));

        /// <summary>
        /// Асинхронно скачать файл
        /// </summary>
        public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, CancellationToken cancellationToken)
        {
            // Считать только заголовок
            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                // А содержимое записать прямо в файл
                using (var download = await response.Content.ReadAsStreamAsync())
                    await download.CopyToAsync(destination);
            }
        }

        /// <summary>
        /// Асинхронно скачать файл с отчётом о прогрессе
        /// </summary>
        public static Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<float> progress) => DownloadAsync(client, requestUri, destination, progress, default);

        /// <summary>
        /// Асинхронно скачать файл с отчётом о прогрессе
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/a/46497896
        /// </remarks>
        public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<float> progress, CancellationToken cancellationToken)
        {
            // Get the http headers first to examine the content length
            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var contentLength = response.Content.Headers.ContentLength;
                using (var download = await response.Content.ReadAsStreamAsync())
                {
                    // Ignore progress reporting when no progress reporter was
                    // passed or when the content length is unknown
                    if (progress == null || !contentLength.HasValue)
                    {
                        await download.CopyToAsync(destination);
                        return;
                    }

                    // Convert absolute progress (bytes downloaded) into relative progress (0% - 100%)
                    var relativeProgress = new Progress<long>(totalBytes => progress.Report((float)totalBytes / contentLength.Value));
                    // Use extension method to report progress while downloading
                    await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
                    progress.Report(1);
                }
            }
        }

        /// <summary>
        /// Асинхронно скачать файл с отчётом о прогрессе
        /// </summary>
        public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<DownloadState> progress, CancellationToken cancellationToken)
        {
            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var contentLength = response.Content.Headers.ContentLength;
                using (var download = await response.Content.ReadAsStreamAsync())
                {
                    if (progress == null || !contentLength.HasValue)
                    {
                        await download.CopyToAsync(destination);
                        return;
                    }
                    var Total = contentLength.Value;
                    var relativeProgress = new Progress<long>(totalBytes => progress.Report(new DownloadState(Total, totalBytes)));
                    await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
                    progress.Report(new DownloadState(Total, Total));
                }
            }
        }

        /// <summary>
        /// Асинхронно получить размер файла
        /// </summary>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static async Task<long?> GetFileSizeAsync(this HttpClient client, string requestUri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Head, requestUri))
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.Headers.ContentLength;
                }
            }

            return null;
        }
    }
}