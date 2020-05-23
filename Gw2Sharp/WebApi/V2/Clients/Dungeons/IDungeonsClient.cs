
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 dungeons endpoint.
    /// </summary>
    public interface IDungeonsClient :
        IAllExpandableClient<Dungeon>,
        IBulkExpandableClient<Dungeon, string>,
        ILocalizedClient,
        IPaginatedClient<Dungeon>
    {
    }
}
