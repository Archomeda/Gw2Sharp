using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard entry score.
    /// </summary>
    public class PvpSeasonLeaderboardEntryScore
    {
        /// <summary>
        /// The score id.
        /// Can be resolved against <see cref="IPvpSeasonsClient"/> in <see cref="PvpSeason.Leaderboards"/>,
        /// <see cref="PvpSeasonLeaderboard.Scorings"/> as <see cref="PvpSeasonLeaderboardScoring.Id"/>.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The score value.
        /// </summary>
        public int Value { get; set; }
    }
}
