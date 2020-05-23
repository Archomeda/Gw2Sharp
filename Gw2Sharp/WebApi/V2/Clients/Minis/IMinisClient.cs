
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 minis endpoint.
    /// </summary>
    public interface IMinisClient :
        IAllExpandableClient<Mini>,
        IBulkExpandableClient<Mini, int>,
        ILocalizedClient,
        IPaginatedClient<Mini>
    {
    }
}
