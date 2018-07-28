using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home cats endpoint.
    /// </summary>
    [EndpointPath("account/home/cats")]
    public class AccountHomeCatsClient : BaseEndpointBlobClient<IReadOnlyList<AccountHomeCat>>, IAccountHomeCatsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountHomeCatsClient"/> that is used for the API v2 account home cats endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountHomeCatsClient(IConnection connection) : base(connection) { }
    }
}
