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
    public class DataFileDownloader
    {
        public event EventHandler<DataFileDownloadEventArgs> DownloadCompleted;
        /// <summary>
        /// Downloads a file from the internet to the local drive.
        /// </summary>
        /// <param name="dataFileUrl">The local file path (including the file name) where the file being downloaded should be saved to.</param>
        /// <param name="csvDataFileUrl">The internet address where the file can be found.</param>
        public async Task DownloadFile(string csvDataFileUrl, string localCsvFilePath)
        {


        }


        protected virtual void OnDownloadCompleted(DataFileDownloadEventArgs e)
        {
            DownloadCompleted?.Invoke(this, e);
        }
    }
}
