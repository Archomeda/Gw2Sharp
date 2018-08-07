using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem backgrounds endpoint.
    /// </summary>
    public interface IEmblemBackgroundsClient :
        IAllExpandableClient<Emblem>,
        IBulkExpandableClient<Emblem, int>,
        IPaginatedClient<Emblem>
    { 
    }
}
