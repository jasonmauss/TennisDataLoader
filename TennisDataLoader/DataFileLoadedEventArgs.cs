using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisDataLoader
{
    /// <summary>
    /// Custom event args class for when a data file has been loaded into the database
    /// </summary>
    public class DataFileLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// The total numbers of rows processed from the data file
        /// </summary>
        public int TotalRowsProcessed { get; set;}

        // how long it took to process all the rows
        public string TimeElapsed { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="totalRowsProcessed"></param>
        /// <param name="timeElapsed"></param>
        public DataFileLoadedEventArgs(int totalRowsProcessed, string timeElapsed)
        {
            TotalRowsProcessed = totalRowsProcessed;
            TimeElapsed = timeElapsed;
        }
    }
}
