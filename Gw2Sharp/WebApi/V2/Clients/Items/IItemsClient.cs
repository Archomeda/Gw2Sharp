using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 items endpoint.
    /// </summary>
    public interface IItemsClient :
        IBulkExpandableClient<Item, int>,
        ILocalizedClient,
        IPaginatedClient<Item>
    {
    }
}
