
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 dailycrafting endpoint.
    /// </summary>
    public interface IDailyCraftingClient :
        IAllExpandableClient<DailyCrafting>,
        IBulkExpandableClient<DailyCrafting, string>,
        IPaginatedClient<DailyCrafting>
    {
    }
}
