using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id log endpoint.
    /// </summary>
    [EndpointPath("guild/:id/log")]
    [EndpointPathSegment("id", 0)]
    public class GuildIdLogClient : BaseEndpointBlobClient<IReadOnlyList<GuildLog>>, IGuildIdLogClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdLogClient"/> that is used for the API v2 guild id log endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public GuildIdLogClient(IConnection connection, Guid guildId) :
            base(connection)
        {
            this.GuildId = guildId;
        }

        /// <inheritdoc />
        public virtual Guid GuildId { get; protected set; }

        /// <inheritdoc />
        [EndpointPathParameter("since")]
        public virtual int? ParamSince { get; set; }

        /// <inheritdoc />
        public virtual IGuildIdLogClient Since(int? since)
        {
            this.ParamSince = since;
            return this;
        }
    }
}
