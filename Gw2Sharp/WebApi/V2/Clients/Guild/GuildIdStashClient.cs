using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id stash endpoint.
    /// </summary>
    [EndpointPath("guild/:id/stash")]
    public class GuildIdStashClient : BaseGuildSubClient<IApiV2ObjectList<GuildStashStorage>>, IGuildIdStashClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdStashClient"/> that is used for the API v2 guild id stash endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal GuildIdStashClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId)
        { }
    }
}
