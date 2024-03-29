using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home cats endpoint.
    /// </summary>
    [EndpointPath("account/home/cats")]
    [EndpointSchemaVersion("2019-03-22T00:00:00.000Z")]
    public class AccountHomeCatsClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountHomeCatsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountHomeCatsClient"/> that is used for the API v2 account home cats endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AccountHomeCatsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
