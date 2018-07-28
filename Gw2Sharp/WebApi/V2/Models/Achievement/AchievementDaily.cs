using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a daily achievement.
    /// </summary>
    public class AchievementDaily
    {
        /// <summary>
        /// The daily achievement id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The daily achievement level requirement.
        /// </summary>
        public AchievementDailyLevel Level { get; set; }

        /// <summary>
        /// The daily achievement access requirement.
        /// </summary>
        public IReadOnlyList<ApiEnum<GameAccess>> RequiredAccess { get; set; }
    }
}
