using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 race endpoint.
    /// </summary>
    [EndpointPath("races")]
    public class RacesClient : BaseEndpointBulkAllClient<Race, string>, IRacesClient
    {
        /// <summary>
        /// Creates a new <see cref="RacesClient"/> that is used for the API v2 race endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal RacesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public Task<Race> GetAsync(RaceType id, CancellationToken cancellationToken = default) =>
            this.GetAsync(id.ToString(), cancellationToken);

        /// <inheritdoc />
        public Task<IReadOnlyList<Race>> ManyAsync(IEnumerable<RaceType> ids, CancellationToken cancellationToken = default) =>
            this.ManyAsync(ids.Select(x => x.ToString()), cancellationToken);
    }
}
