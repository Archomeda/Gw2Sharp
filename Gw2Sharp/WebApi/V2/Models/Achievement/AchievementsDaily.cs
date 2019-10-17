using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the daily achievements.
    /// </summary>
    public class AchievementsDaily : ApiV2BaseObject
    {
        /// <summary>
        /// The daily PvE achievements.
        /// </summary>
        public IReadOnlyList<AchievementDaily> Pve { get; set; } = Array.Empty<AchievementDaily>();

        /// <summary>
        /// The daily PvP achievements.
        /// </summary>
        public IReadOnlyList<AchievementDaily> Pvp { get; set; } = Array.Empty<AchievementDaily>();

        /// <summary>
        /// The daily WvW achievements.
        /// </summary>
        public IReadOnlyList<AchievementDaily> Wvw { get; set; } = Array.Empty<AchievementDaily>();

        /// <summary>
        /// The daily fractals achievements.
        /// </summary>
        public IReadOnlyList<AchievementDaily> Fractals { get; set; } = Array.Empty<AchievementDaily>();

        /// <summary>
        /// The daily special achievements.
        /// </summary>
        public IReadOnlyList<AchievementDaily> Special { get; set; } = Array.Empty<AchievementDaily>();
    }
}
