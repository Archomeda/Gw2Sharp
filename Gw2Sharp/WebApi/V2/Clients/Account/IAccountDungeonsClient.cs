using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account dungeons endpoint.
    /// </summary>
    public interface IAccountDungeonsClient :
        IAuthenticatedClient<IReadOnlyList<string>>,
        IBlobClient<IReadOnlyList<string>>
    {
    }
}
