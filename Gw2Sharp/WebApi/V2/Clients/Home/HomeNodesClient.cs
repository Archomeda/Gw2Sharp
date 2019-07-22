using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home nodes endpoint.
    /// </summary>
    [EndpointPath("home/nodes")]
    public class HomeNodesClient : BaseEndpointBulkAllClient<Node, string>, IHomeNodesClient
    {
        /// <summary>
        /// Creates a new <see cref="HomeNodesClient"/> that is used for the API v2 home nodes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal HomeNodesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
