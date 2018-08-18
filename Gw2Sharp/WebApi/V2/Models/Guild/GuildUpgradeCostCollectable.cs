namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represent a guild upgrade collectible cost.
    /// </summary>
    public class GuildUpgradeCostCollectible : GuildUpgradeCost
    {
        /// <summary>
        /// The cost name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cost item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }
    }
}
