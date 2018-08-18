using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild treasury item.
    /// </summary>
    public class GuildTreasuryItem
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The amount of items stored.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The upgrades that require this item.
        /// </summary>
        public IReadOnlyList<GuildTreasuryItemUpgrade> NeededBy { get; set; }
    }
}
