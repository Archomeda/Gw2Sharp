using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home nodes endpoint.
    /// </summary>
    public interface IAccountHomeNodesClient :
        IAuthenticatedClient<IReadOnlyList<string>>,
        IBlobClient<IReadOnlyList<string>>
    {
    }
}
