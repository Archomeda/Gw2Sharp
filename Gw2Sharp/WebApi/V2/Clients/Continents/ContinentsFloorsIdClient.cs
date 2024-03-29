using System;
using System.Globalization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id")]
    [EndpointPathSegment("continent_id", 0)]
    [EndpointPathSegment("floor_id", 1)]
    public class ContinentsFloorsIdClient : BaseEndpointBlobClient<ContinentFloor>, IContinentsFloorsIdClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly IContinentsFloorsRegionsClient regions;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsIdClient"/> that is used for the API v2 continents floors id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal ContinentsFloorsIdClient(IConnection connection, IGw2Client gw2Client, int continentId, int floorId) :
            base(connection, gw2Client, continentId.ToString(CultureInfo.InvariantCulture), floorId.ToString(CultureInfo.InvariantCulture))
        {
            this.continentId = continentId;
            this.floorId = floorId;
            this.regions = new ContinentsFloorsRegionsClient(connection, gw2Client, continentId, floorId);
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsClient Regions => this.regions;
    }
}
