using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisDataLoader
{
    /// <summary>
    /// This class is responsible for downloading a csv file from the internet
    /// and storing/saving it locally
    /// </summary>
    public class DataFileDownloader : IDisposable
    {
        private bool disposedValue;
        private HttpClient httpClient = new HttpClient();

        public event EventHandler<DataFileDownloadEventArgs>? DownloadCompleted;
        public event EventHandler<DataFileDownloadProgressEventArgs>? ProgressChanged;

        /// <summary>
        /// Downloads a file from the internet to the local drive.
        /// </summary>
        /// <param name="dataFileUrl">The local file path (including the file name) where the file being downloaded should be saved to.</param>
        /// <param name="csvDataFileUrl">The internet address where the file can be found.</param>
        public async Task DownloadFile(string csvDataFileUrl, string localCsvFilePath)
        {
            DataFileDownloadEventArgs args = new DataFileDownloadEventArgs(true, Path.GetFileName(csvDataFileUrl), 0);
            DataFileDownloadProgressEventArgs progressArgs = new DataFileDownloadProgressEventArgs(0);

            try
            {
                var progress = new Progress<double>();
                progress.ProgressChanged += (s, percent) =>
                {
                    progressArgs.ProgressPercentage = percent;
                    ProgressChanged?.Invoke(this, progressArgs);
                };

                using var response = await httpClient.GetAsync(csvDataFileUrl, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                var bytesRead = 0L;

                args.TotalBytesDownloaded = totalBytes;

                using var stream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(localCsvFilePath, FileMode.Create, FileAccess.Write);
                var buffer = new byte[8192];
                var isMoreToRead = true;

                do
                {
                    var read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if(read == 0)
                    {
                        isMoreToRead = false;
                    }
                    else
                    {
                        await fileStream.WriteAsync(buffer, 0, read);
                        bytesRead += read;
                        double percentage = (double)bytesRead / (double)totalBytes;
                        percentage *= 100;
                        // Report progress
                        ((IProgress<double>)progress).Report(percentage);
                    }

                } while (isMoreToRead);

            }
            catch(Exception ex)
            {
                args.FileDownloadedSuccessfully = false;
                args.Exception = ex;
            }

            OnDownloadCompleted(args);

        }


        protected virtual void OnDownloadCompleted(DataFileDownloadEventArgs e)
        {
            //DataFileDownloadProgressEventArgs progressArgs = new DataFileDownloadProgressEventArgs(100D);
            //ProgressChanged?.Invoke(this, progressArgs);
            DownloadCompleted?.Invoke(this, e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataFileDownloader()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
