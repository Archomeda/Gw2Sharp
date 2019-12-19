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
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class AccountClient : BaseEndpointClient<Account>, IAccountClient
    {
        private readonly IAccountAchievementsClient achievements;
        private readonly IAccountBankClient bank;
        private readonly IAccountBuildStorageClient buildStorage;
        private readonly IAccountDailyCraftingClient dailyCrafting;
        private readonly IAccountDungeonsClient dungeons;
        private readonly IAccountDyesClient dyes;
        private readonly IAccountEmotesClient emotes;
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
        private readonly IAccountNoveltiesClient novelties;
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
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal AccountClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.achievements = new AccountAchievementsClient(connection, gw2Client);
            this.bank = new AccountBankClient(connection, gw2Client);
            this.buildStorage = new AccountBuildStorageClient(connection, gw2Client);
            this.dailyCrafting = new AccountDailyCraftingClient(connection, gw2Client);
            this.dungeons = new AccountDungeonsClient(connection, gw2Client);
            this.dyes = new AccountDyesClient(connection, gw2Client);
            this.emotes = new AccountEmotesClient(connection, gw2Client);
            this.finishers = new AccountFinishersClient(connection, gw2Client);
            this.gliders = new AccountGlidersClient(connection, gw2Client);
            this.home = new AccountHomeClient(connection, gw2Client);
            this.inventory = new AccountInventoryClient(connection, gw2Client);
            this.luck = new AccountLuckClient(connection, gw2Client);
            this.mailCarriers = new AccountMailCarriersClient(connection, gw2Client);
            this.mapChests = new AccountMapChestsClient(connection, gw2Client);
            this.masteries = new AccountMasteriesClient(connection, gw2Client);
            this.mastery = new AccountMasteryClient(connection, gw2Client);
            this.materials = new AccountMaterialsClient(connection, gw2Client);
            this.minis = new AccountMinisClient(connection, gw2Client);
            this.mounts = new AccountMountsClient(connection, gw2Client);
            this.novelties = new AccountNoveltiesClient(connection, gw2Client);
            this.outfits = new AccountOutfitsClient(connection, gw2Client);
            this.pvp = new AccountPvpClient(connection, gw2Client);
            this.raids = new AccountRaidsClient(connection, gw2Client);
            this.recipes = new AccountRecipesClient(connection, gw2Client);
            this.skins = new AccountSkinsClient(connection, gw2Client);
            this.titles = new AccountTitlesClient(connection, gw2Client);
            this.wallet = new AccountWalletClient(connection, gw2Client);
            this.worldBosses = new AccountWorldBossesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IAccountAchievementsClient Achievements => this.achievements;

        /// <inheritdoc />
        public virtual IAccountBankClient Bank => this.bank;

        /// <inheritdoc />
        public virtual IAccountBuildStorageClient BuildStorage => this.buildStorage;

        /// <inheritdoc />
        public virtual IAccountDailyCraftingClient DailyCrafting => this.dailyCrafting;

        /// <inheritdoc />
        public virtual IAccountDungeonsClient Dungeons => this.dungeons;

        /// <inheritdoc />
        public virtual IAccountDyesClient Dyes => this.dyes;

        /// <inheritdoc />
        public virtual IAccountEmotesClient Emotes => this.emotes;

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
        public virtual IAccountNoveltiesClient Novelties => this.novelties;

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
        public Task<Account> GetAsync(CancellationToken cancellationToken = default) =>
            this.Implementation.RequestGetAsync(cancellationToken);
    }
}
