using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 tokeninfo endpoint.
    /// </summary>
    [EndpointPath("tokeninfo")]
    [EndpointSchemaVersion("2019-05-22T00:00:00.000Z")]
    public class TokenInfoClient : BaseEndpointBlobClient<TokenInfo>, ITokenInfoClient
    {
        /// <summary>
        /// Creates a new <see cref="TokenInfoClient"/> that is used for the API v2 tokeninfo endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal TokenInfoClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
