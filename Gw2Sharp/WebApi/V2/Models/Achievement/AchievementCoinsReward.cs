namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement coins reward.
    /// </summary>
    public class AchievementCoinsReward : AchievementReward
    {
        /// <summary>
        /// The amount of coins.
        /// </summary>
        public int Count { get; set; }
    }
}
