using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account luck endpoint.
    /// </summary>
    [EndpointPath("account/luck")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    [Obsolete("Deprecated since 2021-09-28. Use Account.Progression instead. This will be removed from Gw2Sharp starting from version 2.0.")]
    public class AccountLuckClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountLuck>>, IAccountLuckClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountLuckClient"/> that is used for the API v2 account luck endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AccountLuckClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
