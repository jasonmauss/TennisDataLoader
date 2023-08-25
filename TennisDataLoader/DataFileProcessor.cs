using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace TennisDataLoader
{
    /// <summary>
    /// This class is primarily responsible for parsing the
    /// .csv file(s) into dotnet POCO/DTO objects which are
    /// to be loaded into a MongoDB database
    /// </summary>
    public abstract class DataFileProcessor
    {
        public DataFileProcessor() { }

        public virtual void ProcessFile(string filePath)
        {

        }
    }
}
