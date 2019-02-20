using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account inventory endpoint.
    /// </summary>
    [EndpointPath("account/inventory")]
    public class AccountInventoryClient : BaseEndpointBlobClient<IReadOnlyList<AccountItem>>, IAccountInventoryClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountInventoryClient"/> that is used for the API v2 account inventory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountInventoryClient(IConnection connection) :
            base(connection)
        { }
    }
}
