using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 wvw abilities endpoint.
    /// </summary>
    public interface IWvwAbilitiesClient :
        IBulkExpandableClient<WvwAbility, int>,
        IAllExpandableClient<WvwAbility>,
        ILocalizedClient
    {
    }
}
