using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 cats endpoint.
    /// </summary>
    [EndpointPath("cats")]
    public class CatsClient : BaseEndpointBulkAllClient<Cat, int>, ICatsClient
    {
        /// <summary>
        /// Creates a new <see cref="CatsClient"/> that is used for the API v2 cats endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CatsClient(IConnection connection) :
            base(connection)
        { }
    }
}
