
using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP heroes endpoint.
    /// </summary>
    public interface IPvpHeroesClient :
        IAllExpandableClient<PvpHero>,
        IBulkExpandableClient<PvpHero, Guid>,
        ILocalizedClient<PvpHero>,
        IPaginatedClient<PvpHero>
    {
    }
}
