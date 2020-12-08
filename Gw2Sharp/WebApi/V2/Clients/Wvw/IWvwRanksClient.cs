
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 wvw ranks endpoint.
    /// </summary>
    public interface IWvwRanksClient :
        IBulkExpandableClient<WvwRank, int>,
        IAllExpandableClient<WvwRank>,
        ILocalizedClient
    {
    }
}
