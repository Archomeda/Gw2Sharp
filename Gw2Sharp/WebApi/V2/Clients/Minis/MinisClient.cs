using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 minis endpoint.
    /// </summary>
    [EndpointPath("minis")]
    public class MinisClient : BaseEndpointBulkAllClient<Mini, int>, IMinisClient
    {
        /// <summary>
        /// Creates a new <see cref="MinisClient"/> that is used for the API v2 minis endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public MinisClient(IConnection connection) :
            base(connection)
        { }
    }
}
