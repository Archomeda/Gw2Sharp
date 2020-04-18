using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 itemstats endpoint.
    /// </summary>
    public interface IItemstatsClient :
        IAllExpandableClient<Itemstat>,
        IBulkExpandableClient<Itemstat, int>,
        ILocalizedClient,
        IPaginatedClient<Itemstat>
    {
    }
}
