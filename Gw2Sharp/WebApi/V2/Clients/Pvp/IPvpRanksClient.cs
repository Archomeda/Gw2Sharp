
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP ranks endpoint.
    /// </summary>
    public interface IPvpRanksClient :
        IAllExpandableClient<PvpRank>,
        IBulkExpandableClient<PvpRank, int>,
        ILocalizedClient<PvpRank>,
        IPaginatedClient<PvpRank>
    {
    }
}
