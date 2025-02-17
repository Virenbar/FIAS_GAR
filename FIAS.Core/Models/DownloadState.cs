namespace FIAS.Core.Models
{
    public class DownloadState
    {
        public DownloadState(float progress)
        {
            Progress = progress;
        }

        public DownloadState(long totalBytes, long downloadedBytes)
        {
            TotalBytes = totalBytes;
            DownloadedBytes = downloadedBytes;
            Progress = (float)downloadedBytes / totalBytes;
        }

        public long? DownloadedBytes { get; }
        public float Progress { get; }
        public long? TotalBytes { get; }
    }
}