using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild endpoint.
    /// </summary>
    [EndpointPath("guild")]
    public class GuildClient : BaseClient, IGuildClient
    {
        private readonly IGuildPermissionsClient permissions;
        private readonly IGuildSearchClient search;
        private readonly IGuildUpgradesClient upgrades;

        /// <summary>
        /// Creates a new <see cref="GuildClient"/> that is used for the API v2 guild endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal GuildClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.permissions = new GuildPermissionsClient(connection, gw2Client);
            this.search = new GuildSearchClient(connection, gw2Client);
            this.upgrades = new GuildUpgradesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IGuildIdClient this[Guid guildId] => new GuildIdClient(this.Connection, this.Gw2Client!, guildId);

        /// <inheritdoc />
        public virtual IGuildIdClient this[string guildId] => this[Guid.Parse(guildId)];

        /// <inheritdoc />
        public virtual IGuildPermissionsClient Permissions => this.permissions;

        /// <inheritdoc />
        public virtual IGuildSearchClient Search => this.search;

        /// <inheritdoc />
        public virtual IGuildUpgradesClient Upgrades => this.upgrades;
    }
}
