
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 currencies endpoint.
    /// </summary>
    public interface ICurrenciesClient :
        IAllExpandableClient<Currency>,
        IBulkExpandableClient<Currency, int>,
        ILocalizedClient,
        IPaginatedClient<Currency>
    {
    }
}
