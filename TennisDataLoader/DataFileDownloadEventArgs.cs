using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisDataLoader
{
    /// <summary>
    /// Custom event args class for when a data file has been downloaded
    /// </summary>
    public class DataFileDownloadEventArgs : EventArgs
    {
        /// <summary>
        /// Whether the file was downloaded successfully or not
        /// </summary>
        public bool FileDownloadedSuccessfully { get; set; }

        /// <summary>
        /// What the name of the downloaded file was
        /// </summary>
        public string FileNameDownloaded { get; set; } = string.Empty;

        /// <summary>
        /// How many total bytes the downloaded file was.
        /// </summary>
        public int TotalBytesDownloaded { get; set; } = 0;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="fileDownloadedSuccessfully"></param>
        /// <param name="fileNameDownloaded"></param>
        /// <param name="totalBytesDownloaded"></param>
        public DataFileDownloadEventArgs(bool fileDownloadedSuccessfully, string fileNameDownloaded, int totalBytesDownloaded)
        {
            FileDownloadedSuccessfully = fileDownloadedSuccessfully;
            FileNameDownloaded = fileNameDownloaded;
            TotalBytesDownloaded = totalBytesDownloaded;
        }
    }
}
