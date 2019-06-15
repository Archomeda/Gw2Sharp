using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts endpoint.
    /// </summary>
    [EndpointPath("account/mounts")]
    public class AccountMountsClient : BaseClient, IAccountMountsClient
    {
        private readonly IAccountMountsSkinsClient skins;
        private readonly IAccountMountsTypesClient types;

        /// <summary>
        /// Creates a new <see cref="AccountMountsClient"/> that is used for the API v2 account home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMountsClient(IConnection connection) :
            base(connection)
        {
            this.skins = new AccountMountsSkinsClient(connection);
            this.types = new AccountMountsTypesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountMountsSkinsClient Skins => this.skins;

        /// <inheritdoc />
        public virtual IAccountMountsTypesClient Types => this.types;
    }
}
