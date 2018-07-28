using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory answers endpoint.
    /// </summary>
    public interface IBackstoryAnswersClient :
        IAllExpandableClient<BackstoryAnswer>,
        IBulkExpandableClient<BackstoryAnswer, string>,
        ILocalizedClient<BackstoryAnswer>,
        IPaginatedClient<BackstoryAnswer>
    { 
    }
}
