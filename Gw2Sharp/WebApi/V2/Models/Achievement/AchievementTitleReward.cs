namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement title reward.
    /// </summary>
    public class AchievementTitleReward : AchievementReward, IIdentifiable<int>
    {
        /// <summary>
        /// The title id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Titles"/>.
        /// </summary>
        public int Id { get; set; }

    }
}
