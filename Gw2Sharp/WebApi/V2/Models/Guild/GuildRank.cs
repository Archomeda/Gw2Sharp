using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild rank.
    /// </summary>
    public class GuildRank
    {
        /// <summary>
        /// The guild rank id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The guild rank order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The guild rank permissions.
        /// Each element can be resolved against <see cref="IGuildClient.Permissions"/>.
        /// </summary>
        public IReadOnlyList<string> Permissions { get; set; }

        /// <summary>
        /// The guild rank icon.
        /// </summary>
        public string Icon { get; set; }
    }
}
