using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild stash storage.
    /// </summary>
    public class GuildStashStorage
    {
        /// <summary>
        /// The storage upgrade id.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public int UpgradeId { get; set; }

        /// <summary>
        /// The stash storage size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The amount of stored coins.
        /// </summary>
        public int Coins { get; set; }

        /// <summary>
        /// The stash storage note.
        /// </summary>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// The stash storage inventory.
        /// </summary>
        public IReadOnlyList<GuildStashItem> Inventory { get; set; } = new List<GuildStashItem>();
    }
}
