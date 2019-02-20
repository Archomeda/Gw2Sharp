using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP heroes endpoint.
    /// </summary>
    [EndpointPath("account/pvp/heroes")]
    public class AccountPvpHeroesClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountPvpHeroesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountPvpHeroesClient"/> that is used for the API v2 account PvP heroes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountPvpHeroesClient(IConnection connection) :
            base(connection)
        { }
    }
}
