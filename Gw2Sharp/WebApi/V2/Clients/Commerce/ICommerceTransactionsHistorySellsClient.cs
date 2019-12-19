using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history sells endpoint.
    /// </summary>
    public interface ICommerceTransactionsHistorySellsClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<CommerceTransactionHistory>>,
        IPaginatedClient<CommerceTransactionHistory>
    {
    }
}
