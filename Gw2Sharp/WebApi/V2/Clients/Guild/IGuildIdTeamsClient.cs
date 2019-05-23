using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id teams endpoint.
    /// </summary>
    public interface IGuildIdTeamsClient :
        IAuthenticatedClient<IApiV2ObjectList<GuildTeam>>,
        IBlobClient<IApiV2ObjectList<GuildTeam>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
