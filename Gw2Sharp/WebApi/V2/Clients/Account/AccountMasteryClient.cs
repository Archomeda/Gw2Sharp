using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mastery endpoint.
    /// </summary>
    [EndpointPath("account/mastery")]
    public class AccountMasteryClient : Gw2WebApiBaseClient, IAccountMasteryClient
    {
        private readonly IAccountMasteryPointsClient points;

        /// <summary>
        /// Creates a new <see cref="AccountMasteriesClient"/> that is used for the API v2 account masteries endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AccountMasteryClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.points = new AccountMasteryPointsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IAccountMasteryPointsClient Points => this.points;
    }
}
