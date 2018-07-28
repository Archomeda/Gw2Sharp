using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account inventory endpoint.
    /// </summary>
    public interface IAccountInventoryClient :
        IAuthenticatedClient<IReadOnlyList<AccountItem>>,
        IBlobClient<IReadOnlyList<AccountItem>>
    {
    }
}
