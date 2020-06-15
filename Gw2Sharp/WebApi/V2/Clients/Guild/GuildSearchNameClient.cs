using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search by name endpoint.
    /// </summary>
    [EndpointPath("guild/search")]
    public class GuildSearchNameClient : BaseEndpointBlobClient<IApiV2ObjectList<Guid>>, IGuildSearchNameClient
    {
        private readonly string name;

        /// <summary>
        /// Creates a new <see cref="GuildSearchNameClient"/> that is used for the API v2 guild search by name endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="name">The guild name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        public GuildSearchNameClient(IConnection connection, IGw2Client gw2Client, string name) :
            base(connection, gw2Client)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        [EndpointQueryParameter("name")]
        public virtual string Name => this.name;
    }
}
