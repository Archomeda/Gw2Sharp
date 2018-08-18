using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild endpoint.
    /// </summary>
    [EndpointPath("guild")]
    public class GuildClient : BaseClient, IGuildClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildClient"/> that is used for the API v2 guild endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public GuildClient(IConnection connection) : base(connection)
        {
            this.Permissions = new GuildPermissionsClient(connection);
            this.Search = new GuildSearchClient(connection);
            this.Upgrades = new GuildUpgradesClient(connection);
        }

        /// <inheritdoc />
        public virtual IGuildIdClient this[Guid guildId] => new GuildIdClient(this.Connection, guildId);

        /// <inheritdoc />
        public virtual IGuildIdClient this[string guildId] => this[Guid.Parse(guildId)];

        /// <inheritdoc />
        public virtual IGuildPermissionsClient Permissions { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildSearchClient Search { get; protected set; }

        /// <inheritdoc />
        public virtual IGuildUpgradesClient Upgrades { get; protected set; }
    }
}
