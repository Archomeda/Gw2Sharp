using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id")]
    [EndpointPathSegment("continent_id", 0)]
    public class ContinentsIdClient : BaseEndpointBlobClient<Continent>, IContinentsIdClient
    {
        private readonly int continentId;
        private readonly IContinentsFloorsClient floors;

        /// <summary>
        /// Creates a new <see cref="ContinentsIdClient"/> that is used for the API v2 continents id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal ContinentsIdClient(IConnection connection, IGw2Client gw2Client, int continentId) :
            base(connection, gw2Client, continentId.ToString())
        {
            this.continentId = continentId;
            this.floors = new ContinentsFloorsClient(connection, gw2Client, continentId);
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual IContinentsFloorsClient Floors => this.floors;
    }
}
