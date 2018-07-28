using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home nodes endpoint.
    /// </summary>
    [EndpointPath("account/home/nodes")]
    public class AccountHomeNodesClient : BaseEndpointBlobClient<IReadOnlyList<string>>, IAccountHomeNodesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountHomeNodesClient"/> that is used for the API v2 account home nodes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountHomeNodesClient(IConnection connection) : base(connection) { }
    }
}
