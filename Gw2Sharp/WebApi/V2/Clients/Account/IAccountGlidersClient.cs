using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account gliders endpoint.
    /// </summary>
    public interface IAccountGlidersClient :
        IAuthenticatedClient<IReadOnlyList<int>>,
        IBlobClient<IReadOnlyList<int>>
    {
    }
}
