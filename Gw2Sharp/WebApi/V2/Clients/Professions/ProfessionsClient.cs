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
    /// A client of the Guild Wars 2 API v2 professions endpoint.
    /// </summary>
    [EndpointPath("professions")]
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class ProfessionsClient : BaseEndpointBulkAllClient<Profession, string>, IProfessionsClient
    {
        /// <summary>
        /// Creates a new <see cref="ProfessionsClient"/> that is used for the API v2 professions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal ProfessionsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public Task<Profession> GetAsync(ProfessionType id, CancellationToken cancellationToken = default) =>
            this.GetAsync(id.ToString(), cancellationToken);

        /// <inheritdoc />
        public Task<IReadOnlyList<Profession>> ManyAsync(IEnumerable<ProfessionType> ids, CancellationToken cancellationToken = default) =>
            this.ManyAsync(ids.Select(x => x.ToString()), cancellationToken);
    }
}
