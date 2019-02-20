using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account dungeons endpoint.
    /// </summary>
    [EndpointPath("account/dungeons")]
    public class AccountDungeonsClient : BaseEndpointBlobClient<IReadOnlyList<string>>, IAccountDungeonsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountDungeonsClient"/> that is used for the API v2 account dungeons endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountDungeonsClient(IConnection connection) :
            base(connection)
        { }
    }
}
