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
        private readonly Guid guildId;
        private readonly IGuildIdLogClient log;
        private readonly IGuildIdMembersClient members;
        private readonly IGuildIdRanksClient ranks;
        private readonly IGuildIdStashClient stash;
        private readonly IGuildIdStorageClient storage;
        private readonly IGuildIdTeamsClient teams;
        private readonly IGuildIdTreasuryClient treasury;
        private readonly IGuildIdUpgradesClient upgrades;

        /// <summary>
        /// Creates a new <see cref="GuildIdClient"/> that is used for the API v2 guild id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public GuildIdClient(IConnection connection, Guid guildId) :
            base(connection)
        {
            this.guildId = guildId;
            this.log = new GuildIdLogClient(connection, guildId);
            this.members = new GuildIdMembersClient(connection, guildId);
            this.ranks = new GuildIdRanksClient(connection, guildId);
            this.stash = new GuildIdStashClient(connection, guildId);
            this.storage = new GuildIdStorageClient(connection, guildId);
            this.teams = new GuildIdTeamsClient(connection, guildId);
            this.treasury = new GuildIdTreasuryClient(connection, guildId);
            this.upgrades = new GuildIdUpgradesClient(connection, guildId);
        }

        /// <inheritdoc />
        public virtual Guid GuildId => this.guildId;

        /// <inheritdoc />
        public virtual IGuildIdLogClient Log => this.log;

        /// <inheritdoc />
        public virtual IGuildIdMembersClient Members => this.members;

        /// <inheritdoc />
        public virtual IGuildIdRanksClient Ranks => this.ranks;

        /// <inheritdoc />
        public virtual IGuildIdStashClient Stash => this.stash;

        /// <inheritdoc />
        public virtual IGuildIdStorageClient Storage => this.storage;

        /// <inheritdoc />
        public virtual IGuildIdTeamsClient Teams => this.teams;

        /// <inheritdoc />
        public virtual IGuildIdTreasuryClient Treasury => this.treasury;

        /// <inheritdoc />
        public virtual IGuildIdUpgradesClient Upgrades => this.upgrades;
    }
}
