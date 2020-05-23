using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 gliders endpoint.
    /// </summary>
    public interface IGlidersClient :
        IAllExpandableClient<Glider>,
        IBulkExpandableClient<Glider, int>,
        ILocalizedClient,
        IPaginatedClient<Glider>
    {
    }
}
