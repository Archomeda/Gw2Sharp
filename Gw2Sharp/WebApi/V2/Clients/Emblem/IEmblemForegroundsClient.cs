using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem foregrounds endpoint.
    /// </summary>
    public interface IEmblemForegroundsClient :
        IAllExpandableClient<Emblem>,
        IBulkExpandableClient<Emblem, int>,
        IPaginatedClient<Emblem>
    { 
    }
}
