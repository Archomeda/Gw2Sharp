namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mastery endpoint.
    /// </summary>
    [EndpointPath("account/mastery")]
    public class AccountMasteryClient : BaseClient, IAccountMasteryClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMasteriesClient"/> that is used for the API v2 account masteries endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountMasteryClient(IConnection connection) : base(connection)
        {
            this.Points = new AccountMasteryPointsClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountMasteryPointsClient Points { get; protected set; }
    }
}
