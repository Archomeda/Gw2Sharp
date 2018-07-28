using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account dyes endpoint.
    /// </summary>
    [EndpointPath("account/dyes")]
    public class AccountDyesClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountDyesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountDyesClient"/> that is used for the API v2 account dyes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountDyesClient(IConnection connection) : base(connection) { }
    }
}
