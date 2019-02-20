using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account raids endpoint.
    /// </summary>
    [EndpointPath("account/raids")]
    public class AccountRaidsClient : BaseEndpointBlobClient<IReadOnlyList<string>>, IAccountRaidsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountRaidsClient"/> that is used for the API v2 account raids endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountRaidsClient(IConnection connection) :
            base(connection)
        { }
    }
}
