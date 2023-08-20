using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisDataLoader.Extensions
{
    /// <summary>
    /// Class that contains extension methods for this project
    /// </summary>
    public static class DataLoaderExtensions
    {
        /// <summary>
        /// Takes a number of bytes and returns a human readable string for the size
        /// for example 1024 bytes would return "1 Mb"
        /// </summary>
        /// <param name="bytes">The number of bytes</param>
        /// <returns>A human readable size of the bytes</returns>
        public static string BytesAsHumanReadableString(this long bytes)
        {
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            const string formatTemplate = "{0}{1:0.#} {2}";

            if (bytes == 0)
            {
                return string.Format(formatTemplate, null, 0, sizeSuffixes[0]);
            }

            var absSize = Math.Abs((double)bytes);
            var fpPower = Math.Log(absSize, 1000);
            var intPower = (int)fpPower;
            var iUnit = intPower >= sizeSuffixes.Length
                ? sizeSuffixes.Length - 1
                : intPower;
            var normSize = absSize / Math.Pow(1000, iUnit);

            return string.Format(
                formatTemplate,
                bytes < 0 ? "-" : null, normSize, sizeSuffixes[iUnit]);
        }
    }
}
