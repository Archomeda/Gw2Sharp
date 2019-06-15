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
        public GuildClient(IConnection connection) :
            base(connection)
        {
            this.permissions = new GuildPermissionsClient(connection);
            this.search = new GuildSearchClient(connection);
            this.upgrades = new GuildUpgradesClient(connection);
        }

        /// <inheritdoc />
        public virtual IGuildIdClient this[Guid guildId] => new GuildIdClient(this.Connection, guildId);

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
