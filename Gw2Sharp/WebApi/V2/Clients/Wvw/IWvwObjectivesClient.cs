
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 wvw objectives endpoint.
    /// </summary>
    public interface IWvwObjectivesClient :
        IBulkExpandableClient<WvwObjective, string>,
        IAllExpandableClient<WvwObjective>,
        ILocalizedClient
    {
    }
}
