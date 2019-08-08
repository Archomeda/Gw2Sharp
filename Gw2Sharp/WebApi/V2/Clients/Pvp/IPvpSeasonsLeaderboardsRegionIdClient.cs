using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP season leaderboard region endpoint.
    /// </summary>
    public interface IPvpSeasonsLeaderboardsRegionIdClient :
        IBlobClient<IApiV2ObjectList<PvpSeasonLeaderboardEntry>>
    {
    }
}
