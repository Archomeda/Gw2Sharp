using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 traits endpoint.
    /// </summary>
    public interface ITraitsClient :
        IAllExpandableClient<Trait>,
        IBulkExpandableClient<Trait, int>,
        ILocalizedClient<Trait>,
        IPaginatedClient<Trait>
    {
    }
}
