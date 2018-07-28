namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement item reward.
    /// </summary>
    public class AchievementItemReward : AchievementReward, IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The number of items.
        /// </summary>
        public int Count { get; set; }
    }
}
