namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard tier.
    /// </summary>
    public class PvpSeasonLeaderboardSettingsTier
    {
        /// <summary>
        /// The leaderboard tier color.
        /// If the leadertier doesn't have a color, this value is <see langword="null"/>.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// The leaderboard tier type.
        /// If the leadertier doesn't have a type, this value is <see langword="null"/>.
        /// </summary>
        public ApiEnum<PvpSeasonLeaderboardSettingsTierType>? Type { get; set; }

        /// <summary>
        /// The leaderboard tier name.
        /// If the leadertier doesn't have a name, this value is <see langword="null"/>.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The leaderboard tier range.
        /// </summary>
        public PvpSeasonLeaderboardSettingsTierRange Range { get; set; } = new PvpSeasonLeaderboardSettingsTierRange();
    }
}
