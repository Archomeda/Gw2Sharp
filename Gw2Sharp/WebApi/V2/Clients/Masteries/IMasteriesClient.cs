
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 masteries endpoint.
    /// </summary>
    public interface IMasteriesClient :
        IAllExpandableClient<Mastery>,
        IBulkExpandableClient<Mastery, int>,
        ILocalizedClient,
        IPaginatedClient<Mastery>
    {
    }
}
