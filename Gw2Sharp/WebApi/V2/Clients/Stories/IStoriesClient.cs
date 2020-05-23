using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 stories endpoint.
    /// </summary>
    public interface IStoriesClient :
        IAllExpandableClient<Story>,
        IBulkExpandableClient<Story, int>,
        ILocalizedClient,
        IPaginatedClient<Story>
    {
        /// <summary>
        /// Gets the stories seasons.
        /// </summary>
        public IStoriesSeasonsClient Seasons { get; }
    }
}
