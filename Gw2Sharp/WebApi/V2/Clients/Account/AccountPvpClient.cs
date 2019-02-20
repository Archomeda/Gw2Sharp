using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP endpoint.
    /// </summary>
    [EndpointPath("account/pvp")]
    public class AccountPvpClient : BaseClient, IAccountPvpClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountPvpClient"/> that is used for the API v2 account PvP endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountPvpClient(IConnection connection) :
            base(connection)
        {
            this.Heroes = new AccountPvpHeroesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountPvpHeroesClient Heroes { get; protected set; }
    }
}
