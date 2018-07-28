namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement item bit.
    /// </summary>
    public class AchievementItemBit : AchievementBit, IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }
    }
}
