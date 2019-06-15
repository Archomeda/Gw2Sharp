using System;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account endpoint.
    /// </summary>
    [EndpointPath("account")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountClient : BaseEndpointClient<Account>, IAccountClient
    {
        private readonly IAccountAchievementsClient achievements;
        private readonly IAccountBankClient bank;
        private readonly IAccountDailyCraftingClient dailyCrafting;
        private readonly IAccountDungeonsClient dungeons;
        private readonly IAccountDyesClient dyes;
        private readonly IAccountFinishersClient finishers;
        private readonly IAccountGlidersClient gliders;
        private readonly IAccountHomeClient home;
        private readonly IAccountInventoryClient inventory;
        private readonly IAccountLuckClient luck;
        private readonly IAccountMailCarriersClient mailCarriers;
        private readonly IAccountMapChestsClient mapChests;
        private readonly IAccountMasteriesClient masteries;
        private readonly IAccountMasteryClient mastery;
        private readonly IAccountMaterialsClient materials;
        private readonly IAccountMinisClient minis;
        private readonly IAccountMountsClient mounts;
        private readonly IAccountOutfitsClient outfits;
        private readonly IAccountPvpClient pvp;
        private readonly IAccountRaidsClient raids;
        private readonly IAccountRecipesClient recipes;
        private readonly IAccountSkinsClient skins;
        private readonly IAccountTitlesClient titles;
        private readonly IAccountWalletClient wallet;
        private readonly IAccountWorldBossesClient worldBosses;

        /// <summary>
        /// Creates a new <see cref="AccountClient"/> that is used for the API v2 account endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountClient(IConnection connection) :
            base(connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            this.achievements = new AccountAchievementsClient(connection);
            this.bank = new AccountBankClient(connection);
            this.dailyCrafting = new AccountDailyCraftingClient(connection);
            this.dungeons = new AccountDungeonsClient(connection);
            this.dyes = new AccountDyesClient(connection);
            this.finishers = new AccountFinishersClient(connection);
            this.gliders = new AccountGlidersClient(connection);
            this.home = new AccountHomeClient(connection);
            this.inventory = new AccountInventoryClient(connection);
            this.luck = new AccountLuckClient(connection);
            this.mailCarriers = new AccountMailCarriersClient(connection);
            this.mapChests = new AccountMapChestsClient(connection);
            this.masteries = new AccountMasteriesClient(connection);
            this.mastery = new AccountMasteryClient(connection);
            this.materials = new AccountMaterialsClient(connection);
            this.minis = new AccountMinisClient(connection);
            this.mounts = new AccountMountsClient(connection);
            this.outfits = new AccountOutfitsClient(connection);
            this.pvp = new AccountPvpClient(connection);
            this.raids = new AccountRaidsClient(connection);
            this.recipes = new AccountRecipesClient(connection);
            this.skins = new AccountSkinsClient(connection);
            this.titles = new AccountTitlesClient(connection);
            this.wallet = new AccountWalletClient(connection);
            this.worldBosses = new AccountWorldBossesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountAchievementsClient Achievements => this.achievements;

        /// <inheritdoc />
        public virtual IAccountBankClient Bank => this.bank;

        /// <inheritdoc />
        public virtual IAccountDailyCraftingClient DailyCrafting => this.dailyCrafting;

        /// <inheritdoc />
        public virtual IAccountDungeonsClient Dungeons => this.dungeons;

        /// <inheritdoc />
        public virtual IAccountDyesClient Dyes => this.dyes;

        /// <inheritdoc />
        public virtual IAccountFinishersClient Finishers => this.finishers;

        /// <inheritdoc />
        public virtual IAccountGlidersClient Gliders => this.gliders;

        /// <inheritdoc />
        public virtual IAccountHomeClient Home => this.home;

        /// <inheritdoc />
        public virtual IAccountInventoryClient Inventory => this.inventory;

        /// <inheritdoc />
        public virtual IAccountLuckClient Luck => this.luck;

        /// <inheritdoc />
        public virtual IAccountMailCarriersClient MailCarriers => this.mailCarriers;

        /// <inheritdoc />
        public virtual IAccountMapChestsClient MapChests => this.mapChests;

        /// <inheritdoc />
        public virtual IAccountMasteriesClient Masteries => this.masteries;

        /// <inheritdoc />
        public virtual IAccountMasteryClient Mastery => this.mastery;

        /// <inheritdoc />
        public virtual IAccountMaterialsClient Materials => this.materials;

        /// <inheritdoc />
        public virtual IAccountMinisClient Minis => this.minis;

        /// <inheritdoc />
        public virtual IAccountMountsClient Mounts => this.mounts;

        /// <inheritdoc />
        public virtual IAccountOutfitsClient Outfits => this.outfits;

        /// <inheritdoc />
        public virtual IAccountPvpClient Pvp => this.pvp;

        /// <inheritdoc />
        public virtual IAccountRaidsClient Raids => this.raids;

        /// <inheritdoc />
        public virtual IAccountRecipesClient Recipes => this.recipes;

        /// <inheritdoc />
        public virtual IAccountSkinsClient Skins => this.skins;

        /// <inheritdoc />
        public virtual IAccountTitlesClient Titles => this.titles;

        /// <inheritdoc />
        public virtual IAccountWalletClient Wallet => this.wallet;

        /// <inheritdoc />
        public virtual IAccountWorldBossesClient WorldBosses => this.worldBosses;


        /// <inheritdoc />
        public Task<Account> GetAsync() =>
            this.RequestGetAsync();

        /// <inheritdoc />
        public Task<Account> GetAsync(CancellationToken cancellationToken) =>
            this.RequestGetAsync(cancellationToken);
    }
}
