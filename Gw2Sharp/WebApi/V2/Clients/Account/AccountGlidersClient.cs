using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account gliders endpoint.
    /// </summary>
    [EndpointPath("account/gliders")]
    public class AccountGlidersClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountGlidersClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountGlidersClient"/> that is used for the API v2 account gliders endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountGlidersClient(IConnection connection) : base(connection) { }
    }
}
