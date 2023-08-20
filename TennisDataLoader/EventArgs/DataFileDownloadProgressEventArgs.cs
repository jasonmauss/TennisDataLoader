using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisDataLoader
{
    /// <summary>
    /// Custom event args class for the data file download progress event
    /// </summary>
    public class DataFileDownloadProgressEventArgs : EventArgs
    {
        /// <summary>
        /// The percentage of progress
        /// </summary>
        public double ProgressPercentage { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="progressPercentage"></param>
        public DataFileDownloadProgressEventArgs(double progressPercentage)
        {
            ProgressPercentage = progressPercentage;
        }
    }
}
