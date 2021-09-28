using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search endpoint.
    /// </summary>
    [EndpointPath("guild/search")]
    public class GuildSearchClient : Gw2WebApiBaseClient, IGuildSearchClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildSearchClient"/> that is used for the API v2 guild search endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal GuildSearchClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public virtual IGuildSearchNameClient Name(string name) => new GuildSearchNameClient(this.Connection, this.Gw2Client!, name);
    }
}
