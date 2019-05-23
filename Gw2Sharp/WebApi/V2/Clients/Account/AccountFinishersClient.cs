using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account finishers endpoint.
    /// </summary>
    [EndpointPath("account/finishers")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountFinishersClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountFinisher>>, IAccountFinishersClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountFinishersClient"/> that is used for the API v2 account finishers endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountFinishersClient(IConnection connection) :
            base(connection)
        { }
    }
}
