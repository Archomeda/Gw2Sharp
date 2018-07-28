
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current sells endpoint.
    /// </summary>
    public interface ICommerceTransactionsCurrentSellsClient :
        IAuthenticatedClient<IReadOnlyList<CommerceTransactionCurrent>>,
        IBlobClient<IReadOnlyList<CommerceTransactionCurrent>>,
        IPaginatedClient<CommerceTransactionCurrent>
    {
    }
}
