using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id ranks endpoint.
    /// </summary>
    [EndpointPath("guild/:id/ranks")]
    [EndpointPathSegment("id", 0)]
    public class GuildIdRanksClient : BaseEndpointBlobClient<IReadOnlyList<GuildRank>>, IGuildIdRanksClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdRanksClient"/> that is used for the API v2 guild id ranks endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="guildId">The guild id.</param>
        public GuildIdRanksClient(IConnection connection, Guid guildId) : base(connection)
        {
            this.GuildId = guildId;
        }

        /// <inheritdoc />
        public virtual Guid GuildId { get; protected set; }
    }
}
