using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account recipes endpoint.
    /// </summary>
    public interface IAccountRecipesClient : 
        IAuthenticatedClient<IReadOnlyList<int>>,
        IBlobClient<IReadOnlyList<int>>
    {
    }
}
