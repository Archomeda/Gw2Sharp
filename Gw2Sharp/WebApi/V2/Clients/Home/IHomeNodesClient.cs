
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home nodes endpoint.
    /// </summary>
    public interface IHomeNodesClient :
        IAllExpandableClient<Node>,
        IBulkExpandableClient<Node, string>,
        IPaginatedClient<Node>
    {
    }
}
