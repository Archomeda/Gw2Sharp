
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emotes endpoint.
    /// </summary>
    public interface IEmotesClient :
        IAllExpandableClient<Emote>,
        IBulkExpandableClient<Emote, string>,
        IPaginatedClient<Emote>
    {
    }
}
