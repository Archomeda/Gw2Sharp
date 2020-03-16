using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 legends endpoint.
    /// </summary>
    public interface ILegendsClient :
        IAllExpandableClient<Legend>,
        IBulkExpandableClient<Legend, string>,
        IBulkAliasExpandableClient<Legend, LegendType>,
        IPaginatedClient<Legend>
    {
    }
}
