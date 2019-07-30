using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard.
    /// </summary>
    public class PvpSeasonLeaderboard
    {
        /// <summary>
        /// The ladder settings.
        /// </summary>
        public PvpSeasonLeaderboardSettings Settings { get; set; } = new PvpSeasonLeaderboardSettings();

        /// <summary>
        /// The ladder scorings.
        /// </summary>
        public IReadOnlyList<PvpSeasonLeaderboardScoring> Scorings { get; set; } = new List<PvpSeasonLeaderboardScoring>();
    }
}
