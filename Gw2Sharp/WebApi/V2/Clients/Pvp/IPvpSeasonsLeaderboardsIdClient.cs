using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP season leaderboards id endpoint.
    /// </summary>
    public interface IPvpSeasonsLeaderboardsIdClient :
        IBlobClient<IApiV2ObjectList<string>>
    {
        /// <summary>
        /// The PvP season id.
        /// </summary>
        Guid SeasonId { get; }

        /// <summary>
        /// The PvP season leaderboard id.
        /// </summary>
        string LeaderboardId { get; }

        /// <summary>
        /// Gets a PvP season leaderboard region by id.
        /// </summary>
        IPvpSeasonsLeaderboardsRegionIdClient this[string regionId] { get; }
    }
}
