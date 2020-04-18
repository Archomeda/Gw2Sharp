
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 finisher endpoint.
    /// </summary>
    public interface IFinishersClient :
        IAllExpandableClient<Finisher>,
        IBulkExpandableClient<Finisher, int>,
        ILocalizedClient,
        IPaginatedClient<Finisher>
    {
    }
}
