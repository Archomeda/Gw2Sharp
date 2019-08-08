
using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons endpoint.
    /// </summary>
    public interface IPvpSeasonsClient :
        IAllExpandableClient<PvpSeason>,
        IBulkExpandableClient<PvpSeason, Guid>,
        ILocalizedClient<PvpSeason>,
        IPaginatedClient<PvpSeason>
    {
        /// <summary>
        /// Gets a PvP season by id.
        /// </summary>
        IPvpSeasonsIdClient this[Guid seasonId] { get; }

        /// <summary>
        /// Gets a PvP season by id.
        /// </summary>
        IPvpSeasonsIdClient this[string seasonId] { get; }
    }
}
