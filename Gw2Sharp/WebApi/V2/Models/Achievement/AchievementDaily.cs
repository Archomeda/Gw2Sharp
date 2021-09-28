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
        public AchievementDailyLevel Level { get; set; } = new AchievementDailyLevel();

        /// <summary>
        /// The daily achievement game access requirement.
        /// If there are no game access requirements, this value is <see langword="null"/>.
        /// </summary>
        public AchievementDailyAccess? RequiredAccess { get; set; }
    }
}
