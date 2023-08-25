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

        [JsonPropertyName("tournamentId")]
        public string TournamentID { get; set; } = string.Empty;

        [JsonPropertyName("tournamentName")]
        public string TournamentName { get; set; } = string.Empty;

        [JsonPropertyName("surfaceType")]
        public string SurfaceType { get; set; } = string.Empty;

        [JsonPropertyName("drawSize")]
        public int DrawSize { get; set; }

        [JsonPropertyName("tournamentLevel")]
        public string TournamentLevel { get; set; } = string.Empty;

        [JsonPropertyName("tournamentDate")]
        public DateTime TournamentDate { get; set; }

        [JsonPropertyName("matchNumber")]
        public int MatchNumber { get; set; }

        [JsonPropertyName("winnerPlayerId")]
        public long WinnerPlayerID { get; set; }

        [JsonPropertyName("winnerPlayerSeed")]
        public int WinnerPlayerSeed { get; set; }

        [JsonPropertyName("winnerEntry")]
        public string WinnerEntry { get; set; } = string.Empty;

        [JsonPropertyName("winnerName")]
        public string WinnerName { get; set; } = string.Empty;

        [JsonPropertyName("winnerHandedness")]
        public string WinnerHandedness { get; set; } = string.Empty;

        [JsonPropertyName("winnerHeightInCentimeters")]
        public int WinnerHeightInCentimeters { get; set; }

        [JsonPropertyName("winnerCountryAbbrevitation")]
        public string WinnerCountryAbbreviation { get; set; } = string.Empty;

        [JsonPropertyName("winnerAge")]
        public decimal WinnerAge { get; set; }

        [JsonPropertyName("loserPlayerId")]
        public long LoserPlayerID { get; set; }

        [JsonPropertyName("loserPlayerSeed")]
        public int LoserPlayerSeed { get; set; }

        [JsonPropertyName("loserEntry")]
        public string LoserEntry { get; set; } = string.Empty;

        [JsonPropertyName("loserName")]
        public string LoserName { get; set; } = string.Empty;

        [JsonPropertyName("loserHandedness")]
        public string LoserHandedness { get; set; } = string.Empty;

        [JsonPropertyName("loserHeightInCentimeters")]
        public int LoserHeightInCentimeters { get; set; }

        [JsonPropertyName("loserCountryAbbreviation")]
        public string LoserCountryAbbreviation { get; set; } = string.Empty;

        [JsonPropertyName("loserAge")]
        public decimal LoserAge { get; set; }

        [JsonPropertyName("boxScore")]
        public string BoxScore { get; set; }

        [JsonPropertyName("bestOfSets")]
        public int BestOfSets { get; set; }

        [JsonPropertyName("tournamentRound")]
        public string TournamentRound { get; set; }

        [JsonPropertyName("matchMinutesElapsed")]
        public int MatchMinutesElapsed { get; set; }

        [JsonPropertyName("winnerAces")]
        public int WinnerAces { get; set; }

        [JsonPropertyName("winnerDoubleFaults")]
        public int WinnerDoubleFaults { get; set; }

        [JsonPropertyName("winnerServicePoints")]
        public int WinnerServicePoints { get; set; }

        [JsonPropertyName("winnerFirstServesIn")]
        public int WinnerFirstServesIn { get; set; }

        [JsonPropertyName("winnerFirstServesWon")]
        public int WinnerFirstServesWon { get; set; }

        [JsonPropertyName("winnerSecondServesWon")]
        public int WinnerSecondServesWon { get; set; }

        [JsonPropertyName("winnerServiceGames")]
        public int WinnerServicesGames { get; set; }

        [JsonPropertyName("winnerBreakPointsSaved")]
        public int WinnerBreakPointsSaved { get; set; }

        [JsonPropertyName("winnerBreakPointsFaced")]
        public int WinnerBreakPointsFaced { get; set; }

        [JsonPropertyName("loserAces")]
        public int LoserAces { get; set; }

        [JsonPropertyName("loserDoubleFaults")]
        public int LoserDoubleFaults { get; set; }

        [JsonPropertyName("loserServicePoints")]
        public int LoserServicePoints { get; set; }

        [JsonPropertyName("loserFirstServesIn")]
        public int LoserFirstServesIn { get; set; }

        [JsonPropertyName("loserFirstServesWon")]
        public int LoserFirstServesWon { get; set; }

        [JsonPropertyName("loserSecondServesWon")]
        public int LoserSecondServesWon { get; set; }

        [JsonPropertyName("loserServiceGames")]
        public int LoserServicesGames { get; set; }

        [JsonPropertyName("loserBreakPointsSaved")]
        public int LoserBreakPointsSaved { get; set; }

        [JsonPropertyName("loserBreakPointsFaced")]
        public int LoserBreakPointsFaced { get; set; }

        [JsonPropertyName("winnerRank")]
        public int WinnerRank { get; set; }

        [JsonPropertyName("winnerRankPoints")]
        public int WinnerRankPoints { get; set; }

        [JsonPropertyName("loserRank")]
        public int LoserRank { get; set; }

        [JsonPropertyName("loserRankPoints")]
        public int LoserRankPoints { get; set; }

    }
}
