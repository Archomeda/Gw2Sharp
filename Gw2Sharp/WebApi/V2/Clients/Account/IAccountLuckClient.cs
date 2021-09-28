using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Deprecated. Use <see cref="IAccountProgressionClient"/> instead.
    /// </summary>
    [Obsolete("This has been deprecated since version 2.0. Use Account.Progression instead.", true)]
    public interface IAccountLuckClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<AccountLuck>>
    {
    }
}
