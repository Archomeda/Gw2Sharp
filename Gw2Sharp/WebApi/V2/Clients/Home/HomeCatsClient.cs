using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home cats endpoint.
    /// </summary>
    [EndpointPath("home/cats")]
    public class HomeCatsClient : BaseEndpointBulkAllClient<Cat, int>, IHomeCatsClient
    {
        /// <summary>
        /// Creates a new <see cref="HomeCatsClient"/> that is used for the API v2 home cats endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public HomeCatsClient(IConnection connection) :
            base(connection)
        { }
    }
}
