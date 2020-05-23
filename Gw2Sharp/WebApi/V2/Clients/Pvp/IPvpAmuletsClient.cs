
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP amulets endpoint.
    /// </summary>
    public interface IPvpAmuletsClient :
        IAllExpandableClient<PvpAmulet>,
        IBulkExpandableClient<PvpAmulet, int>,
        ILocalizedClient,
        IPaginatedClient<PvpAmulet>
    {
    }
}
