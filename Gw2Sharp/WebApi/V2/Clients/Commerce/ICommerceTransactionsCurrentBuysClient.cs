using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current buys endpoint.
    /// </summary>
    public interface ICommerceTransactionsCurrentBuysClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<CommerceTransactionCurrent>>,
        IPaginatedClient<CommerceTransactionCurrent>
    {
    }
}
