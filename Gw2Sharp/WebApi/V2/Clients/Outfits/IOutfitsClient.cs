using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 outfits endpoint.
    /// </summary>
    public interface IOutfitsClient :
        IAllExpandableClient<Outfit>,
        IBulkExpandableClient<Outfit, int>,
        ILocalizedClient,
        IPaginatedClient<Outfit>
    {
    }
}
