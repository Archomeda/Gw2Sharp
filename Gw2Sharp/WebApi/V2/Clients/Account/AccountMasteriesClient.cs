using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account masteries endpoint.
    /// </summary>
    [EndpointPath("account/masteries")]
    public class AccountMasteriesClient : BaseEndpointBlobClient<IReadOnlyList<AccountMastery>>, IAccountMasteriesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMasteriesClient"/> that is used for the API v2 account masteries endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMasteriesClient(IConnection connection) :
            base(connection)
        { }
    }
}
