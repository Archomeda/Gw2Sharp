using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions")]
    [EndpointPathSegment("continent_id", 0)]
    [EndpointPathSegment("floor_id", 1)]
    public class ContinentsFloorsRegionsClient : BaseEndpointBulkAllClient<ContinentFloorRegion, int>, IContinentsFloorsRegionsClient
    {
        private readonly int continentId;
        private readonly int floorId;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsClient"/> that is used for the API v2 characters floors regions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal ContinentsFloorsRegionsClient(IConnection connection, IGw2Client gw2Client, int continentId, int floorId) :
            base(connection, gw2Client, continentId.ToString(), floorId.ToString())
        {
            this.continentId = continentId;
            this.floorId = floorId;
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsIdClient this[int regionId] => new ContinentsFloorsRegionsIdClient(this.Connection, this.Gw2Client!, this.ContinentId, this.FloorId, regionId);
    }
}
