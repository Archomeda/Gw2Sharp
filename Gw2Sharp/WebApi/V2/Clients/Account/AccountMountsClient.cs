using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts endpoint.
    /// </summary>
    [EndpointPath("account/mounts")]
    public class AccountMountsClient : BaseClient, IAccountMountsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMountsClient"/> that is used for the API v2 account home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMountsClient(IConnection connection) :
            base(connection)
        {
            this.Skins = new AccountMountsSkinsClient(connection);
            this.Types = new AccountMountsTypesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountMountsSkinsClient Skins { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMountsTypesClient Types { get; protected set; }
    }
}
