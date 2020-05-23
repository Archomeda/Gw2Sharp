
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mapchests endpoint.
    /// </summary>
    public interface IMapChestsClient :
        IAllExpandableClient<MapChest>,
        IBulkExpandableClient<MapChest, string>,
        ILocalizedClient,
        IPaginatedClient<MapChest>
    {
    }
}
