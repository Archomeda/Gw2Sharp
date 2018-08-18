using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id upgrades endpoint.
    /// </summary>
    public interface IGuildIdUpgradesClient :
        IAuthenticatedClient<IReadOnlyList<int>>,
        IBlobClient<IReadOnlyList<int>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
