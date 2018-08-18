using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id storage endpoint.
    /// </summary>
    public interface IGuildIdStorageClient :
        IAuthenticatedClient<IReadOnlyList<GuildStorageItem>>,
        IBlobClient<IReadOnlyList<GuildStorageItem>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
