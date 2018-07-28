using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory questions endpoint.
    /// </summary>
    [EndpointPath("backstory/questions")]
    public class BackstoryQuestionsClient : BaseEndpointBulkAllClient<BackstoryQuestion, int>, IBackstoryQuestionsClient
    {
        /// <summary>
        /// Creates a new <see cref="BackstoryQuestionsClient"/> that is used for the API v2 backstory questions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public BackstoryQuestionsClient(IConnection connection) : base(connection) { }
    }
}
