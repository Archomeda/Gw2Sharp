namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement tier.
    /// </summary>
    public class AchievementTier
    {
        /// <summary>
        /// The amount of objectives to complete for this tier.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The amount of achievement points that are awarded upon reaching this tier.
        /// </summary>
        public int Points { get; set; }
    }
}
