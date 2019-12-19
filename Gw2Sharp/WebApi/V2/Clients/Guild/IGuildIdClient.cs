
using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id endpoint.
    /// </summary>
    public interface IGuildIdClient :
        IAuthenticatedClient,
        IBlobClient<Guild>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }

        /// <summary>
        /// Gets the guild log.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdLogClient Log { get; }

        /// <summary>
        /// Gets the guild members.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdMembersClient Members { get; }

        /// <summary>
        /// Gets the guild ranks.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdRanksClient Ranks { get; }

        /// <summary>
        /// Gets the guild stash.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdStashClient Stash { get; }

        /// <summary>
        /// Gets the guild storage.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdStorageClient Storage { get; }

        /// <summary>
        /// Gets the guild teams.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdTeamsClient Teams { get; }

        /// <summary>
        /// Gets the guild treasury.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdTreasuryClient Treasury { get; }

        /// <summary>
        /// Gets the guild upgrades.
        /// Requires scopes: guilds (leader).
        /// </summary>
        IGuildIdUpgradesClient Upgrades { get; }
    }
}
