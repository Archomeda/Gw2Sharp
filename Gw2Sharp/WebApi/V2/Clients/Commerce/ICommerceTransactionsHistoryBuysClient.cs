
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history buys endpoint.
    /// </summary>
    public interface ICommerceTransactionsHistoryBuysClient :
        IAuthenticatedClient<IReadOnlyList<CommerceTransactionHistory>>,
        IBlobClient<IReadOnlyList<CommerceTransactionHistory>>,
        IPaginatedClient<CommerceTransactionHistory>
    {
    }
}
