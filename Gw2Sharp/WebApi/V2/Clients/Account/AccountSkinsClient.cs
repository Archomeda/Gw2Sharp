using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account skins endpoint.
    /// </summary>
    [EndpointPath("account/skins")]
    public class AccountSkinsClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountSkinsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountSkinsClient"/> that is used for the API v2 account skins endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountSkinsClient(IConnection connection) :
            base(connection)
        { }
    }
}
