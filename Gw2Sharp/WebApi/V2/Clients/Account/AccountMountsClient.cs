using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts endpoint.
    /// </summary>
    [EndpointPath("account/mounts")]
    public class AccountMountsClient : Gw2WebApiBaseClient, IAccountMountsClient
    {
        private readonly IAccountMountsSkinsClient skins;
        private readonly IAccountMountsTypesClient types;

        /// <summary>
        /// Creates a new <see cref="AccountMountsClient"/> that is used for the API v2 account home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AccountMountsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.skins = new AccountMountsSkinsClient(connection, gw2Client);
            this.types = new AccountMountsTypesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IAccountMountsSkinsClient Skins => this.skins;

        /// <inheritdoc />
        public virtual IAccountMountsTypesClient Types => this.types;
    }
}
