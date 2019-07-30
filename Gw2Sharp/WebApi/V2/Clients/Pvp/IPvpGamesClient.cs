
using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP games endpoint.
    /// </summary>
    public interface IPvpGamesClient :
        IAllExpandableClient<PvpGame>,
        IAuthenticatedClient<PvpGame>,
        IBulkExpandableClient<PvpGame, Guid>,
        IPaginatedClient<PvpGame>
    {
    }
}
