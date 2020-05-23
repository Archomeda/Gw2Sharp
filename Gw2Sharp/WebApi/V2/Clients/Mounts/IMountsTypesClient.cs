
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mounts types endpoint.
    /// </summary>
    public interface IMountsTypesClient :
        IAllExpandableClient<MountType>,
        IBulkExpandableClient<MountType, string>,
        ILocalizedClient,
        IPaginatedClient<MountType>
    {
    }
}
