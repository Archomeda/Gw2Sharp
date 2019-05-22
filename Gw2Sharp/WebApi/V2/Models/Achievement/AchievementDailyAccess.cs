namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a daily achievement access requirement.
    /// </summary>
    public class AchievementDailyAccess
    {
        /// <summary>
        /// The daily achievement product requirement.
        /// </summary>
        public GameAccess Product { get; set; }

        /// <summary>
        /// The daily achievement condition requirement.
        /// </summary>
        public AccessCondition Condition { get; set; }
    }
}
