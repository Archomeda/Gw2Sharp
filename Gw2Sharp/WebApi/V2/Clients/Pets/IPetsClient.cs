using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 pets endpoint.
    /// </summary>
    public interface IPetsClient :
        IAllExpandableClient<Pet>,
        IBulkExpandableClient<Pet, int>,
        ILocalizedClient,
        IPaginatedClient<Pet>
    {
    }
}
