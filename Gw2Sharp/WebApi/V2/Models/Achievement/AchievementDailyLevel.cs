namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a daily achievement level requirement.
    /// </summary>
    public class AchievementDailyLevel
    {
        /// <summary>
        /// The daily achievement minimum level requirement.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// The daily achievement maximum level requirement.
        /// </summary>
        public int Max { get; set; }
    }
}
