using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account wallet endpoint.
    /// </summary>
    [EndpointPath("account/wallet")]
    public class AccountWalletClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountCurrency>>, IAccountWalletClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountWalletClient"/> that is used for the API v2 account wallet endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountWalletClient(IConnection connection) :
            base(connection)
        { }
    }
}
