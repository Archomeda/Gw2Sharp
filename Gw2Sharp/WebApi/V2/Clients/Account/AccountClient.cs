using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account endpoint.
    /// </summary>
    [EndpointPath("account")]
    public class AccountClient : BaseEndpointClient<Account>, IAccountClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountClient"/> that is used for the API v2 account endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountClient(IConnection connection) : base(connection)
        {
            this.Achievements = new AccountAchievementsClient(connection);
            this.Bank = new AccountBankClient(connection);
            this.Dungeons = new AccountDungeonsClient(connection);
            this.Dyes = new AccountDyesClient(connection);
            this.Finishers = new AccountFinishersClient(connection);
            this.Gliders = new AccountGlidersClient(connection);
            this.Home = new AccountHomeClient(connection);
            this.Inventory = new AccountInventoryClient(connection);
            this.MailCarriers = new AccountMailCarriersClient(connection);
            this.Masteries = new AccountMasteriesClient(connection);
            this.Mastery = new AccountMasteryClient(connection);
            this.Materials = new AccountMaterialsClient(connection);
            this.Minis = new AccountMinisClient(connection);
            this.Outfits = new AccountOutfitsClient(connection);
            this.Pvp = new AccountPvpClient(connection);
            this.Raids = new AccountRaidsClient(connection);
            this.Recipes = new AccountRecipesClient(connection);
            this.Skins = new AccountSkinsClient(connection);
            this.Titles = new AccountTitlesClient(connection);
            this.Wallet = new AccountWalletClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountAchievementsClient Achievements { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountBankClient Bank { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountDungeonsClient Dungeons { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountDyesClient Dyes { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountFinishersClient Finishers { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountGlidersClient Gliders { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountHomeClient Home { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountInventoryClient Inventory { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMailCarriersClient MailCarriers { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMasteriesClient Masteries { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMasteryClient Mastery { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMaterialsClient Materials { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountMinisClient Minis { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountOutfitsClient Outfits { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountPvpClient Pvp { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountRaidsClient Raids { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountRecipesClient Recipes { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountSkinsClient Skins { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountTitlesClient Titles { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountWalletClient Wallet { get; protected set; }


        /// <inheritdoc />
        public Task<Account> Get() =>
            this.RequestGet();

        /// <inheritdoc />
        public Task<Account> Get(CancellationToken cancellationToken) =>
            this.RequestGet(cancellationToken);

        /// <inheritdoc />
        public Task<IApiV2Response<Account>> GetWithResponse(CancellationToken cancellationToken) =>
            this.RequestGetWithResponse(cancellationToken);
    }
}
