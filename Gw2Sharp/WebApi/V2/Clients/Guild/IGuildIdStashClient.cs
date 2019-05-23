using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id stash endpoint.
    /// </summary>
    public interface IGuildIdStashClient :
        IAuthenticatedClient<IApiV2ObjectList<GuildStashStorage>>,
        IBlobClient<IApiV2ObjectList<GuildStashStorage>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
