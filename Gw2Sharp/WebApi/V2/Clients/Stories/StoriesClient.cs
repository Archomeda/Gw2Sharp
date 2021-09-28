using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 stories endpoint.
    /// </summary>
    [EndpointPath("stories")]
    public class StoriesClient : BaseEndpointBulkAllClient<Story, int>, IStoriesClient
    {
        private readonly IStoriesSeasonsClient seasons;

        /// <summary>
        /// Creates a new <see cref="StoriesClient"/> that is used for the API v2 stories endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal StoriesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.seasons = new StoriesSeasonsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IStoriesSeasonsClient Seasons => this.seasons;
    }
}
