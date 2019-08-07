using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 quests endpoint.
    /// </summary>
    public interface IQuestsClient :
        IAllExpandableClient<Quest>,
        IBulkExpandableClient<Quest, int>,
        ILocalizedClient<Quest>,
        IPaginatedClient<Quest>
    {
    }
}
