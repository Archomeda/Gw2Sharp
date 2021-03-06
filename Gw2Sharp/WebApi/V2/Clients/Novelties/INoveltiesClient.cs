using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 novelties endpoint.
    /// </summary>
    public interface INoveltiesClient :
        IAllExpandableClient<Novelty>,
        IBulkExpandableClient<Novelty, int>,
        ILocalizedClient,
        IPaginatedClient<Novelty>
    {
    }
}
