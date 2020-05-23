using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 worlds endpoint.
    /// </summary>
    public interface IWorldsClient :
        IAllExpandableClient<World>,
        IBulkExpandableClient<World, int>,
        ILocalizedClient,
        IPaginatedClient<World>
    { }
}
