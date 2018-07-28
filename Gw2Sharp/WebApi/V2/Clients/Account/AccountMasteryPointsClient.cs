using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mastery points endpoint.
    /// </summary>
    [EndpointPath("account/mastery/points")]
    public class AccountMasteryPointsClient : BaseEndpointBlobClient<AccountMasteryPoints>, IAccountMasteryPointsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMasteryPointsClient"/> that is used for the API v2 account mastery points endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountMasteryPointsClient(IConnection connection) : base(connection) { }
    }
}
