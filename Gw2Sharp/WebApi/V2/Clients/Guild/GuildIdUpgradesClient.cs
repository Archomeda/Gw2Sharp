using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id upgrades endpoint.
    /// </summary>
    [EndpointPath("guild/:id/upgrades")]
    public class GuildIdUpgradesClient : BaseGuildSubClient<IApiV2ObjectList<int>>, IGuildIdUpgradesClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdUpgradesClient"/> that is used for the API v2 guild id upgrades endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        public GuildIdUpgradesClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId)
        { }
    }
}
