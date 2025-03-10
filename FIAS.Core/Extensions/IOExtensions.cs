﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FIAS.Core.Extensions
{
    public static class IOExtensions
    {
        public static Task CopyToAsync(this Stream source, Stream destination, int bufferSize) => CopyToAsync(source, destination, bufferSize, default, default);

        public static Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<long> progress) => CopyToAsync(source, destination, bufferSize, progress, default);

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/a/46497896
        /// </remarks>
        public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<long> progress, CancellationToken cancellationToken)
        {
            if (source is null) { throw new ArgumentNullException(nameof(source)); }
            if (!source.CanRead) { throw new ArgumentException("Has to be readable", nameof(source)); }
            if (destination is null) { throw new ArgumentNullException(nameof(destination)); }
            if (!destination.CanWrite) { throw new ArgumentException("Has to be writable", nameof(destination)); }
            if (bufferSize < 0) { throw new ArgumentOutOfRangeException(nameof(bufferSize)); }

            var buffer = new byte[bufferSize];
            long totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0)
            {
                await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                totalBytesRead += bytesRead;
                progress?.Report(totalBytesRead);
            }
        }
    }
}