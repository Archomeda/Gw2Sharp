using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account titles endpoint.
    /// </summary>
    [EndpointPath("account/titles")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountTitlesClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountTitlesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountTitlesClient"/> that is used for the API v2 account titles endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal AccountTitlesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
