using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id members endpoint.
    /// </summary>
    public interface IGuildIdMembersClient :
        IAuthenticatedClient<IApiV2ObjectList<GuildMember>>,
        IBlobClient<IApiV2ObjectList<GuildMember>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
