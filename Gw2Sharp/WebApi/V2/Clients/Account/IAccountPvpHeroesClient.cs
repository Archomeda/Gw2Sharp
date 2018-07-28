using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP heroes endpoint.
    /// </summary>
    public interface IAccountPvpHeroesClient : 
        IAuthenticatedClient<IReadOnlyList<int>>,
        IBlobClient<IReadOnlyList<int>>
    {
    }
}
