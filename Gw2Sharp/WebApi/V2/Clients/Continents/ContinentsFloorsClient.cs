using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors")]
    [EndpointPathSegment("continent_id", 0)]
    public class ContinentsFloorsClient : BaseEndpointBulkAllClient<ContinentFloor, int>, IContinentsFloorsClient
    {
        private readonly int continentId;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsClient"/> that is used for the API v2 characters floors endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public ContinentsFloorsClient(IConnection connection, int continentId) :
            base(connection, continentId.ToString())
        {
            this.continentId = continentId;
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual IContinentsFloorsIdClient this[int floorId] => new ContinentsFloorsIdClient(this.Connection, this.ContinentId, floorId);
    }
}
