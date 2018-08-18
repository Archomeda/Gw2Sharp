namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild stash log.
    /// </summary>
    public class GuildLogStash : GuildLog
    {
        /// <summary>
        /// The stash operation.
        /// </summary>
        public ApiEnum<GuildLogStashOperation> Operation { get; set; }

        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The amount of items.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The amount of coins.
        /// </summary>
        public int Coins { get; set; }
    }
}
