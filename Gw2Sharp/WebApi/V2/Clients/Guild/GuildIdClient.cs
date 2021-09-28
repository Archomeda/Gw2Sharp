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
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal GuildIdClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId.ToString())
        {
            this.guildId = guildId;
            this.log = new GuildIdLogClient(connection, gw2Client, guildId);
            this.members = new GuildIdMembersClient(connection, gw2Client, guildId);
            this.ranks = new GuildIdRanksClient(connection, gw2Client, guildId);
            this.stash = new GuildIdStashClient(connection, gw2Client, guildId);
            this.storage = new GuildIdStorageClient(connection, gw2Client, guildId);
            this.teams = new GuildIdTeamsClient(connection, gw2Client, guildId);
            this.treasury = new GuildIdTreasuryClient(connection, gw2Client, guildId);
            this.upgrades = new GuildIdUpgradesClient(connection, gw2Client, guildId);
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
