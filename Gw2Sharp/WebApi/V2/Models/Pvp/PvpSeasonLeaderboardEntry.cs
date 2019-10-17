using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard entry.
    /// </summary>
    public class PvpSeasonLeaderboardEntry
    {
        /// <summary>
        /// The account name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The leaderboard rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// The leaderboard entry date.
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// The leaderboard scores.
        /// </summary>
        public IReadOnlyList<PvpSeasonLeaderboardEntryScore> Scores { get; set; } = Array.Empty<PvpSeasonLeaderboardEntryScore>();
    }
}
