using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account bank endpoint.
    /// </summary>
    [EndpointPath("account/bank")]
    public class AccountBankClient : BaseEndpointBlobClient<IReadOnlyList<AccountItem>>, IAccountBankClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountBankClient"/> that is used for the API v2 account bank endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountBankClient(IConnection connection) :
            base(connection)
        { }
    }
}
