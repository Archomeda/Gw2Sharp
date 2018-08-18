using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search by name endpoint.
    /// </summary>
    [EndpointPath("guild/search")]
    public class GuildSearchNameClient : BaseEndpointBlobClient<IReadOnlyList<Guid>>, IGuildSearchNameClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildSearchNameClient"/> that is used for the API v2 guild search by name endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="name">The guild name.</param>
        public GuildSearchNameClient(IConnection connection, string name) : base(connection)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        [EndpointPathParameter("name")]
        public virtual string Name { get; protected set; }
    }
}
