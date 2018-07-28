
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce prices endpoint.
    /// </summary>
    public interface ICommercePricesClient :
        IBulkExpandableClient<CommercePrices, int>,
        IPaginatedClient<CommercePrices>
    {
    }
}
