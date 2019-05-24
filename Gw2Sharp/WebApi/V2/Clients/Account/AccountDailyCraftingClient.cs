using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account dailycrafting endpoint.
    /// </summary>
    [EndpointPath("account/dailycrafting")]
    public class AccountDailyCraftingClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IAccountDailyCraftingClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountDailyCraftingClient"/> that is used for the API v2 account dailycrafting endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountDailyCraftingClient(IConnection connection) :
            base(connection)
        { }
    }
}
