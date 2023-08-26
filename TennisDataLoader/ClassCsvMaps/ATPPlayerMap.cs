using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisDataLoader.Models;

namespace TennisDataLoader.ClassCsvMaps
{
    public sealed class ATPPlayerMap : ClassMap<ATPPlayer>
    {
        /// <summary>
        /// This mapping class instructs CSVHelper how to map the data
        /// to the properties found in the ATPPlayer class.
        /// </summary>
        public ATPPlayerMap()
        {
            Map(m => m.PlayerID).Name("player_id");
            Map(m => m.FirstName).Name("name_first");
            Map(m => m.LastName).Name("name_last");
            Map(m => m.Handedness).Name("hand");
            Map(m => m.DateOfBirth).Name("dob").Convert(x => ParseDate(x.Row.GetField<string>(4)));
            Map(m => m.CountryAbbreviation).Name("ioc");
            Map(m => m.HeightInCentimeters).Name("height");
            Map(m => m.WikiDataID).Name("wikidata_id");
        }

        /// <summary>
        /// Some date of birth values in the CSV file have only 
        /// a year and "0000" for the month and day, so we must accommodate
        /// for that here and just make it January 1st since the date of birth
        /// isn't really that important for our purposes with this data
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static DateTime? ParseDate(string date)
        {
            if(date == null) return null;
            if(string.IsNullOrWhiteSpace(date)) return null;

            if(date.EndsWith("0000"))
            {
                return DateTime.ParseExact(date.Substring(0, 4) + "0101", "yyyyMMdd", CultureInfo.InvariantCulture);
            }

            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}
