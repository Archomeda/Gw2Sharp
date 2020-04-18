
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mailcarriers endpoint.
    /// </summary>
    public interface IMailCarriersClient :
        IAllExpandableClient<MailCarrier>,
        IBulkExpandableClient<MailCarrier, int>,
        ILocalizedClient,
        IPaginatedClient<MailCarrier>
    {
    }
}
