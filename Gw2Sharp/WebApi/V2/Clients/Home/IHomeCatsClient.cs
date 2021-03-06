
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home cats endpoint.
    /// </summary>
    public interface IHomeCatsClient :
        IAllExpandableClient<Cat>,
        IBulkExpandableClient<Cat, int>,
        IPaginatedClient<Cat>
    {
    }
}
