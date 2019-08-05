using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP standings endpoint.
    /// </summary>
    public interface IPvpStandingsClient :
        IAuthenticatedClient<ApiV2BaseObjectList<PvpStanding>>,
        IBlobClient<ApiV2BaseObjectList<PvpStanding>>
    {
    }
}
