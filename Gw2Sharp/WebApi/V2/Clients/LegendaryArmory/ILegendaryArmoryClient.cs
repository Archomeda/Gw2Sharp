using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 legendary armory endpoint.
    /// </summary>
    public interface ILegendaryArmoryClient :
        IAllExpandableClient<LegendaryArmory>,
        IBulkExpandableClient<LegendaryArmory, int>,
        IPaginatedClient<LegendaryArmory>
    {
    }
}
