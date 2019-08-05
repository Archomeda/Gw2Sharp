using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 quaggans endpoint.
    /// </summary>
    public interface IQuaggansClient :
        IAllExpandableClient<Quaggan>,
        IBulkExpandableClient<Quaggan, string>,
        IPaginatedClient<Quaggan>
    {
    }
}
