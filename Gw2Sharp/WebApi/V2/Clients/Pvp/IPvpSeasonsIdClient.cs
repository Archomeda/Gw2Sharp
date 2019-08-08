using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons id endpoint.
    /// </summary>
    public interface IPvpSeasonsIdClient :
        IBlobClient<PvpSeason>
    {
        /// <summary>
        /// The PvP season id.
        /// </summary>
        Guid SeasonId { get; }

        /// <summary>
        /// The PvP season leaderboards.
        /// </summary>
        IPvpSeasonsLeaderboardsClient Leaderboards { get; }
    }
}
