using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id teams endpoint.
    /// </summary>
    [EndpointPath("guild/:id/teams")]
    public class GuildIdTeamsClient : BaseGuildSubClient<IApiV2ObjectList<GuildTeam>>, IGuildIdTeamsClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdTeamsClient"/> that is used for the API v2 guild id teams endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal GuildIdTeamsClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId)
        { }
    }
}
