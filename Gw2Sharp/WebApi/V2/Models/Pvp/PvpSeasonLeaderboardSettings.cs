using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard settings.
    /// </summary>
    public class PvpSeasonLeaderboardSettings
    {
        /// <summary>
        /// The leaderboard name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The leaderboard duration.
        /// This value is <c>null</c> if it's unavailable.
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The leaderboard primary scoring id.
        /// Can be matched with ...
        /// </summary>
        public Guid Scoring { get; set; }

        /// <summary>
        /// The leaderboard tiers.
        /// </summary>
        public IReadOnlyList<PvpSeasonLeaderboardSettingsTier> Tiers { get; set; } = Array.Empty<PvpSeasonLeaderboardSettingsTier>();
    }
}
