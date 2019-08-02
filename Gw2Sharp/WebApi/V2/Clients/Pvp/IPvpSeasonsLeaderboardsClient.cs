using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP season leaderboards endpoint.
    /// </summary>
    public interface IPvpSeasonsLeaderboardsClient :
        IBlobClient<IApiV2ObjectList<string>>
    {
        /// <summary>
        /// The PvP season id.
        /// </summary>
        Guid SeasonId { get; }

        /// <summary>
        /// Gets a PvP season leaderboard by id.
        /// </summary>
        IPvpSeasonsLeaderboardsIdClient this[string leaderboardId] { get; }
    }
}
