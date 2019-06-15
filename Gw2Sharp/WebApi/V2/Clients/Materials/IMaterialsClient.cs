
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 materials endpoint.
    /// </summary>
    public interface IMaterialsClient :
        IAllExpandableClient<MaterialCategory>,
        IBulkExpandableClient<MaterialCategory, int>,
        ILocalizedClient<MaterialCategory>,
        IPaginatedClient<MaterialCategory>
    {
    }
}
