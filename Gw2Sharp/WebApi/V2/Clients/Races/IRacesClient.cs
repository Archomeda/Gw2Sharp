using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 races endpoint.
    /// </summary>
    public interface IRacesClient :
        IAllExpandableClient<Race>,
        IBulkExpandableClient<Race, string>,
        ILocalizedClient<Race>,
        IPaginatedClient<Race>
    {
    }
}
