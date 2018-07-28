using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account titles endpoint.
    /// </summary>
    [EndpointPath("account/titles")]
    public class AccountTitlesClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountTitlesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountTitlesClient"/> that is used for the API v2 account titles endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountTitlesClient(IConnection connection) : base(connection) { }
    }
}
