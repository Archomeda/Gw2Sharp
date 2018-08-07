using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents endpoint.
    /// </summary>
    [EndpointPath("continents")]
    public class ContinentsClient : BaseEndpointBulkAllClient<Continent, int>, IContinentsClient
    {
        /// <summary>
        /// Creates a new <see cref="ContinentsClient"/> that is used for the API v2 characters endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public ContinentsClient(IConnection connection) : base(connection) { }

        /// <inheritdoc />
        public virtual IContinentsIdClient this[int continentId] => new ContinentsIdClient(this.Connection, continentId);
    }
}
