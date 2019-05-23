using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id treasury endpoint.
    /// </summary>
    public interface IGuildIdTreasuryClient :
        IAuthenticatedClient<IApiV2ObjectList<GuildTreasuryItem>>,
        IBlobClient<IApiV2ObjectList<GuildTreasuryItem>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
