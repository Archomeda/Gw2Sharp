using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mail carriers endpoint.
    /// </summary>
    [EndpointPath("account/mailcarriers")]
    public class AccountMailCarriersClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountMailCarriersClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMailCarriersClient"/> that is used for the API v2 account mail carriers endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountMailCarriersClient(IConnection connection) : base(connection) { }
    }
}
