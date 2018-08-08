
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 files endpoint.
    /// </summary>
    public interface IFilesClient :
        IAllExpandableClient<File>,
        IBulkExpandableClient<File, string>,
        IPaginatedClient<File>
    {
    }
}
