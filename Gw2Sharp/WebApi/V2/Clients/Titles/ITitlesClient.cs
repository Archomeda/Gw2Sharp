using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 titles endpoint.
    /// </summary>
    public interface ITitlesClient :
        IAllExpandableClient<Title>,
        IBulkExpandableClient<Title, int>,
        ILocalizedClient,
        IPaginatedClient<Title>
    {
    }
}
