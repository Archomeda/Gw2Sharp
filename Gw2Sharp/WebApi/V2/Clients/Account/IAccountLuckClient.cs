using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account luck endpoint.
    /// </summary>
    [Obsolete("Deprecated since 2021-09-28. Use Account.Progression instead. This will be removed from Gw2Sharp starting from version 2.0.")]
    public interface IAccountLuckClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<AccountLuck>>
    {
    }
}
