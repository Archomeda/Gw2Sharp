using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 skins endpoint.
    /// </summary>
    public interface ISkinsClient :
        IBulkExpandableClient<Skin, int>,
        ILocalizedClient<Skin>,
        IPaginatedClient<Skin>
    {
    }
}
