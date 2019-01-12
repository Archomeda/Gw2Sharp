namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement mastery reward.
    /// </summary>
    public class AchievementMasteryReward : AchievementReward, IIdentifiable<int>
    {
        /// <summary>
        /// The mastery point id that is awarded.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mastery point region.
        /// </summary>
        public string Region { get; set; } = string.Empty;
    }
}
