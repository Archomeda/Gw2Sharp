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
        public ApiEnum<GameAccess> Product { get; set; } = new ApiEnum<GameAccess>();

        /// <summary>
        /// The daily achievement condition requirement.
        /// </summary>
        public ApiEnum<AccessCondition> Condition { get; set; } = new ApiEnum<AccessCondition>();
    }
}
