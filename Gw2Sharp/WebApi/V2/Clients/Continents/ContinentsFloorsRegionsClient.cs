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
        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsClient"/> that is used for the API v2 characters floors regions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        public ContinentsFloorsRegionsClient(IConnection connection, int continentId, int floorId) : base(connection, continentId.ToString(), floorId.ToString())
        {
            this.ContinentId = continentId;
            this.FloorId = floorId;
        }

        /// <inheritdoc />
        public virtual int ContinentId { get; protected set; }

        /// <inheritdoc />
        public virtual int FloorId { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsIdClient this[int regionId] => new ContinentsFloorsRegionsIdClient(this.Connection, this.ContinentId, this.FloorId, regionId);
    }
}
