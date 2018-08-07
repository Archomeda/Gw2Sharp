using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory questions endpoint.
    /// </summary>
    public interface IBackstoryQuestionsClient :
        IAllExpandableClient<BackstoryQuestion>,
        IBulkExpandableClient<BackstoryQuestion, int>,
        ILocalizedClient<BackstoryQuestion>,
        IPaginatedClient<BackstoryQuestion>
    { 
    }
}
