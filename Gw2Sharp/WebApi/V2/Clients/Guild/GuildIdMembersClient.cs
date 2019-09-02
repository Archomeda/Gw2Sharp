using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id members endpoint.
    /// </summary>
    [EndpointPath("guild/:id/members")]
    public class GuildIdMembersClient : BaseGuildSubClient<IApiV2ObjectList<GuildMember>>, IGuildIdMembersClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildIdMembersClient"/> that is used for the API v2 guild id members endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal GuildIdMembersClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId)
        { }
    }
}
