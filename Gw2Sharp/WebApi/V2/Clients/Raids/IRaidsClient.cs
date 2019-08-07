using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 raids endpoint.
    /// </summary>
    public interface IRaidsClient :
        IAllExpandableClient<Raid>,
        IBulkExpandableClient<Raid, string>,
        IPaginatedClient<Raid>
    {
    }
}
