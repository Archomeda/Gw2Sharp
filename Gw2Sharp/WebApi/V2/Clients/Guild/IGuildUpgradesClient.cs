using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild upgrades endpoint.
    /// </summary>
    public interface IGuildUpgradesClient :
        IAllExpandableClient<GuildUpgrade>,
        IBulkExpandableClient<GuildUpgrade, int>,
        ILocalizedClient<GuildUpgrade>,
        IPaginatedClient<GuildUpgrade>
    {
    }
}
