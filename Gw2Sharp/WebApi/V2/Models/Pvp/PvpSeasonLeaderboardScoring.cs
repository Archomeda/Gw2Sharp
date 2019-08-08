using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard scoring.
    /// </summary>
    public class PvpSeasonLeaderboardScoring
    {
        /// <summary>
        /// The scoring id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The scoring type.
        /// </summary>
        public ApiEnum<PvpSeasonLeaderboardScoringType> Type { get; set; } = new ApiEnum<PvpSeasonLeaderboardScoringType>();

        /// <summary>
        /// The scoring description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The scoring name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The scoring order.
        /// </summary>
        public ApiEnum<PvpSeasonLeaderboardScoringOrder> Ordering { get; set; } = new ApiEnum<PvpSeasonLeaderboardScoringOrder>();
    }
}
