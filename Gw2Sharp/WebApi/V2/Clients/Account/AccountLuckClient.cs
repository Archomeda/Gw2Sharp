using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Deprecated. Use <see cref="AccountProgressionClient"/> instead.
    /// </summary>
    [EndpointPath("account/luck")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    [Obsolete("This has been deprecated since version 2.0. Use Account.Progression instead.", true)]
    public class AccountLuckClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountLuck>>, IAccountLuckClient
    {
        /// <summary>
        /// Deprecated. Use <see cref="AccountProgressionClient"/> instead.
        /// </summary>
        protected internal AccountLuckClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
