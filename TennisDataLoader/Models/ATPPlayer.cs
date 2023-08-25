using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TennisDataLoader.Models
{
    public class ATPPlayer
    {
        public ATPPlayer() { }

        /// <summary>
        /// Numeric identifier for the player
        /// </summary>
        [JsonPropertyName("playerId")]
        public long PlayerID { get; set; }

        /// <summary>
        /// The players first name
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The players last name
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The players dominant hand / the hand they hit their forehand with
        /// </summary>
        [JsonPropertyName("handedness")]
        public string Handedness { get; set; } = string.Empty;

        /// <summary>
        /// The players date of birth
        /// </summary>
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The three character IOC abbreviation for the country the player is a citizen of
        /// </summary>
        [JsonPropertyName("countryAbbreviation")]
        public string CountryAbbreviation { get; set; } = string.Empty;

        /// <summary>
        /// How tall the player is, measured in centimeters
        /// </summary>
        [JsonPropertyName("heightInCentimeters")]
        public int HeightInCentimeters { get; set; }

        /// <summary>
        /// The Wikipedia identifier for the players page on the Wikipedia website
        /// </summary>
        [JsonPropertyName("wikiDataId")]
        public string WikiDataID { get; set; } = string.Empty;


    }
}
