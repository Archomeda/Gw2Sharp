using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id storage endpoint.
    /// </summary>
    [EndpointPath("guild/:id/storage")]
    public class GuildIdStorageClient : BaseGuildSubClient<IApiV2ObjectList<GuildStorageItem>>, IGuildIdStorageClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdStorageClient"/> that is used for the API v2 guild id storage endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal GuildIdStorageClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId)
        { }
    }
}
