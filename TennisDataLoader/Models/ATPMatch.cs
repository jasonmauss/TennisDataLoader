using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TennisDataLoader.Models
{
    /// <summary>
    /// This class represents a professional tennis singles match that was played between two opponents
    /// </summary>
    public class ATPMatch
    {
        public ATPMatch() { }

        [BsonElement("tournamentId")]
        [JsonPropertyName("tournamentId")]
        public string TournamentID { get; set; } = string.Empty;

        [BsonElement("tournamentName")]
        [JsonPropertyName("tournamentName")]
        public string TournamentName { get; set; } = string.Empty;

        [BsonElement("surfaceType")]
        [JsonPropertyName("surfaceType")]
        public string SurfaceType { get; set; } = string.Empty;

        [BsonElement("drawSize")]
        [JsonPropertyName("drawSize")]
        public int? DrawSize { get; set; }

        [BsonElement("tournamentLevel")]
        [JsonPropertyName("tournamentLevel")]
        public string TournamentLevel { get; set; } = string.Empty;

        [BsonElement("tournamentDate")]
        [JsonPropertyName("tournamentDate")]
        public DateTime? TournamentDate { get; set; }

        [BsonElement("matchNumber")]
        [JsonPropertyName("matchNumber")]
        public int? MatchNumber { get; set; }

        [BsonElement("winnerPlayerId")]
        [JsonPropertyName("winnerPlayerId")]
        public long WinnerPlayerID { get; set; }

        [BsonElement("winnerPlayerSeed")]
        [JsonPropertyName("winnerPlayerSeed")]
        public int? WinnerPlayerSeed { get; set; }

        [BsonElement("winnerEntry")]
        [JsonPropertyName("winnerEntry")]
        public string WinnerEntry { get; set; } = string.Empty;

        [BsonElement("winnerName")]
        [JsonPropertyName("winnerName")]
        public string WinnerName { get; set; } = string.Empty;

        [BsonElement("winnerHandedness")]
        [JsonPropertyName("winnerHandedness")]
        public string WinnerHandedness { get; set; } = string.Empty;

        [BsonElement("winnerHeightInCentimeters")]
        [JsonPropertyName("winnerHeightInCentimeters")]
        public int? WinnerHeightInCentimeters { get; set; }

        [BsonElement("winnerCountryAbbreviation")]
        [JsonPropertyName("winnerCountryAbbreviation")]
        public string WinnerCountryAbbreviation { get; set; } = string.Empty;

        [BsonElement("winnerAge")]
        [JsonPropertyName("winnerAge")]
        public decimal? WinnerAge { get; set; }

        [BsonElement("loserPlayerId")]
        [JsonPropertyName("loserPlayerId")]
        public long LoserPlayerID { get; set; }

        [BsonElement("loserPlayerSeed")]
        [JsonPropertyName("loserPlayerSeed")]
        public int? LoserPlayerSeed { get; set; }

        [BsonElement("loserEntry")]
        [JsonPropertyName("loserEntry")]
        public string LoserEntry { get; set; } = string.Empty;

        [BsonElement("loserName")]
        [JsonPropertyName("loserName")]
        public string LoserName { get; set; } = string.Empty;

        [BsonElement("loserHandedness")]
        [JsonPropertyName("loserHandedness")]
        public string LoserHandedness { get; set; } = string.Empty;

        [BsonElement("loserHeightInCentimeters")]
        [JsonPropertyName("loserHeightInCentimeters")]
        public int? LoserHeightInCentimeters { get; set; }

        [BsonElement("loserCountryAbbreviation")]
        [JsonPropertyName("loserCountryAbbreviation")]
        public string LoserCountryAbbreviation { get; set; } = string.Empty;

        [BsonElement("loserAge")]
        [JsonPropertyName("loserAge")]
        public decimal? LoserAge { get; set; }

        [BsonElement("boxScore")]
        [JsonPropertyName("boxScore")]
        public string BoxScore { get; set; }

        [BsonElement("bestOfSets")]
        [JsonPropertyName("bestOfSets")]
        public int BestOfSets { get; set; }

        [BsonElement("tournamentRound")]
        [JsonPropertyName("tournamentRound")]
        public string TournamentRound { get; set; }

        [BsonElement("matchMinutesElapsed")]
        [JsonPropertyName("matchMinutesElapsed")]
        public int? MatchMinutesElapsed { get; set; }

        [BsonElement("winnerAces")]
        [JsonPropertyName("winnerAces")]
        public int? WinnerAces { get; set; }

        [BsonElement("winnerDoubleFaults")]
        [JsonPropertyName("winnerDoubleFaults")]
        public int? WinnerDoubleFaults { get; set; }

        [BsonElement("winnerServicePoints")]
        [JsonPropertyName("winnerServicePoints")]
        public int? WinnerServicePoints { get; set; }

        [BsonElement("winnerFirstServesIn")]
        [JsonPropertyName("winnerFirstServesIn")]
        public int? WinnerFirstServesIn { get; set; }

        [BsonElement("winnerFirstServesWon")]
        [JsonPropertyName("winnerFirstServesWon")]
        public int? WinnerFirstServesWon { get; set; }

        [BsonElement("winnerSecondServesWon")]
        [JsonPropertyName("winnerSecondServesWon")]
        public int? WinnerSecondServesWon { get; set; }

        [BsonElement("winnerServiceGames")]
        [JsonPropertyName("winnerServiceGames")]
        public int? WinnerServicesGames { get; set; }

        [BsonElement("winnerBreakPointsSaved")]
        [JsonPropertyName("winnerBreakPointsSaved")]
        public int? WinnerBreakPointsSaved { get; set; }

        [BsonElement("winnerBreakPointsFaced")]
        [JsonPropertyName("winnerBreakPointsFaced")]
        public int? WinnerBreakPointsFaced { get; set; }

        [BsonElement("loserAces")]
        [JsonPropertyName("loserAces")]
        public int? LoserAces { get; set; }

        [BsonElement("loserDoubleFaults")]
        [JsonPropertyName("loserDoubleFaults")]
        public int? LoserDoubleFaults { get; set; }

        [BsonElement("loserServicePoints")]
        [JsonPropertyName("loserServicePoints")]
        public int? LoserServicePoints { get; set; }

        [BsonElement("loserFirstServesIn")]
        [JsonPropertyName("loserFirstServesIn")]
        public int? LoserFirstServesIn { get; set; }

        [BsonElement("loserFirstServesWon")]
        [JsonPropertyName("loserFirstServesWon")]
        public int? LoserFirstServesWon { get; set; }

        [BsonElement("loserSecondServesWon")]
        [JsonPropertyName("loserSecondServesWon")]
        public int? LoserSecondServesWon { get; set; }

        [BsonElement("loserServiceGames")]
        [JsonPropertyName("loserServiceGames")]
        public int? LoserServicesGames { get; set; }

        [BsonElement("loserBreakPointsSaved")]
        [JsonPropertyName("loserBreakPointsSaved")]
        public int? LoserBreakPointsSaved { get; set; }

        [BsonElement("loserBreakPointsFaced")]
        [JsonPropertyName("loserBreakPointsFaced")]
        public int? LoserBreakPointsFaced { get; set; }

        [BsonElement("winnerRank")]
        [JsonPropertyName("winnerRank")]
        public int? WinnerRank { get; set; }

        [BsonElement("winnerRankPoints")]
        [JsonPropertyName("winnerRankPoints")]
        public int? WinnerRankPoints { get; set; }

        [BsonElement("loserRank")]
        [JsonPropertyName("loserRank")]
        public int? LoserRank { get; set; }

        [BsonElement("loserRankPoints")]
        [JsonPropertyName("loserRankPoints")]
        public int? LoserRankPoints { get; set; }


    }
}
