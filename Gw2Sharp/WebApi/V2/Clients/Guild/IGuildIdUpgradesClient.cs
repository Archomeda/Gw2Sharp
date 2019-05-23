using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id upgrades endpoint.
    /// </summary>
    public interface IGuildIdUpgradesClient :
        IAuthenticatedClient<IApiV2ObjectList<int>>,
        IBlobClient<IApiV2ObjectList<int>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }
    }
}
