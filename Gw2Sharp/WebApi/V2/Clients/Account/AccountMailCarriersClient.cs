using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mail carriers endpoint.
    /// </summary>
    [EndpointPath("account/mailcarriers")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountMailCarriersClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountMailCarriersClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMailCarriersClient"/> that is used for the API v2 account mail carriers endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal AccountMailCarriersClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
