using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id endpoint.
    /// </summary>
    [EndpointPath("guild/:id")]
    [EndpointPathSegment("id", 0)]
    public class GuildIdClient : BaseEndpointBlobClient<Guild>, IGuildIdClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdClient"/> that is used for the API v2 guild id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public GuildIdClient(IConnection connection, Guid guildId) :
            base(connection)
        {
            this.GuildId = guildId;
            this.Log = new GuildIdLogClient(connection, guildId);
            this.Members = new GuildIdMembersClient(connection, guildId);
            this.Ranks = new GuildIdRanksClient(connection, guildId);
            this.Stash = new GuildIdStashClient(connection, guildId);
            this.Storage = new GuildIdStorageClient(connection, guildId);
            this.Teams = new GuildIdTeamsClient(connection, guildId);
            this.Treasury = new GuildIdTreasuryClient(connection, guildId);
            this.Upgrades = new GuildIdUpgradesClient(connection, guildId);
        }

        /// <inheritdoc />
        public virtual Guid GuildId { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdLogClient Log { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdMembersClient Members { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdRanksClient Ranks { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdStashClient Stash { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdStorageClient Storage { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdTeamsClient Teams { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdTreasuryClient Treasury { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildIdUpgradesClient Upgrades { get; protected set; }
    }
}
