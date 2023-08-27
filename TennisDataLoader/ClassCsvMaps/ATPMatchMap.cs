using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisDataLoader.Models;

namespace TennisDataLoader.ClassCsvMaps
{
    public sealed class ATPMatchMap : ClassMap<ATPMatch>
    {
        public ATPMatchMap()
        {
            Map(m => m.TournamentID).Name("tourney_id");
            Map(m => m.TournamentName).Name("tourney_name");
            Map(m => m.SurfaceType).Name("surface");
            Map(m => m.DrawSize).Name("draw_size");
            Map(m => m.TournamentLevel).Name("tourney_level");
            Map(m => m.TournamentDate).Name("tourney_date");
            Map(m => m.MatchNumber).Name("match_num");
            Map(m => m.WinnerPlayerID).Name("winner_id");
            Map(m => m.WinnerPlayerSeed).Name("winner_seed");
            Map(m => m.WinnerEntry).Name("winner_entry");
            Map(m => m.WinnerName).Name("winner_name");
            Map(m => m.WinnerHandedness).Name("winner_hand");
            Map(m => m.WinnerHeightInCentimeters).Name("winner_ht");
            Map(m => m.WinnerCountryAbbreviation).Name("winner_ioc");
            Map(m => m.WinnerAge).Name("winner_age");
            Map(m => m.LoserPlayerID).Name("loser_id");
            Map(m => m.LoserPlayerSeed).Name("loser_seed");
            Map(m => m.LoserEntry).Name("loser_entry");
            Map(m => m.LoserName).Name("loser_name");
            Map(m => m.LoserHandedness).Name("loser_hand");
            Map(m => m.LoserHeightInCentimeters).Name("loser_ht");
            Map(m => m.LoserCountryAbbreviation).Name("loser_ioc");
            Map(m => m.LoserAge).Name("loser_age");
            Map(m => m.BoxScore).Name("score");
            Map(m => m.BestOfSets).Name("best_of");
            Map(m => m.TournamentRound).Name("round");
            Map(m => m.MatchMinutesElapsed).Name("minutes");
            Map(m => m.WinnerAces).Name("w_ace");
            Map(m => m.WinnerDoubleFaults).Name("w_df");
            Map(m => m.WinnerServicePoints).Name("w_svpt");
            Map(m => m.WinnerFirstServesIn).Name("w_1stIn");
            Map(m => m.WinnerFirstServesWon).Name("w_1stWon");
            Map(m => m.WinnerSecondServesWon).Name("w_2ndWon");
            Map(m => m.WinnerServicesGames).Name("w_SvGms");
            Map(m => m.WinnerBreakPointsSaved).Name("w_bpSaved");
            Map(m => m.WinnerBreakPointsFaced).Name("w_bpFaced");
            Map(m => m.LoserAces).Name("l_ace");
            Map(m => m.LoserDoubleFaults).Name("l_df");
            Map(m => m.LoserServicePoints).Name("l_svpt");
            Map(m => m.LoserFirstServesIn).Name("l_1stIn");
            Map(m => m.LoserFirstServesWon).Name("l_1stWon");
            Map(m => m.LoserSecondServesWon).Name("l_2ndWon");
            Map(m => m.LoserServicesGames).Name("l_SvGms");
            Map(m => m.LoserBreakPointsSaved).Name("l_bpSaved");
            Map(m => m.LoserBreakPointsFaced).Name("l_bpFaced");
            Map(m => m.WinnerRank).Name("winner_rank");
            Map(m => m.WinnerRankPoints).Name("winner_rank_points");
            Map(m => m.LoserRank).Name("loser_rank");
            Map(m => m.LoserRankPoints).Name("loser_rank_points");
        }
    }
}
