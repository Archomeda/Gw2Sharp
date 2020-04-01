using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 stories seasons endpoint.
    /// </summary>
    public interface IStoriesSeasonsClient :
        IAllExpandableClient<StorySeason>,
        IBulkExpandableClient<StorySeason, Guid>,
        ILocalizedClient<StorySeason>,
        IPaginatedClient<StorySeason>
    {
    }
}
