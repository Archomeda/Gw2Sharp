
using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild endpoint.
    /// </summary>
    public interface IGuildClient
    {
        /// <summary>
        /// Gets a guild by id.
        /// </summary>
        IGuildIdClient this[Guid guildId] { get; }

        /// <summary>
        /// Gets a guild by id.
        /// </summary>
        IGuildIdClient this[string guildId] { get; }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        IGuildPermissionsClient Permissions { get; }

        /// <summary>
        /// Gets the searcher.
        /// </summary>
        IGuildSearchClient Search { get; }

        /// <summary>
        /// Gets the upgrades.
        /// </summary>
        IGuildUpgradesClient Upgrades { get; }
    }
}
