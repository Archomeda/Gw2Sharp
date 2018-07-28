using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 backstory answers endpoint.
    /// </summary>
    [EndpointPath("backstory/answers")]
    public class BackstoryAnswersClient : BaseEndpointBulkAllClient<BackstoryAnswer, string>, IBackstoryAnswersClient
    {
        /// <summary>
        /// Creates a new <see cref="BackstoryAnswersClient"/> that is used for the API v2 backstory answers endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public BackstoryAnswersClient(IConnection connection) : base(connection) { }
    }
}
