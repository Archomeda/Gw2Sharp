using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// A client for the Guild Wars 2 web API v2.
    /// </summary>
    public class Gw2WebApiV2Client : IGw2WebApiV2Client
    {
        /// <summary>
        /// The base URL for making Guild Wars 2 API v2 requests.
        /// </summary>
        internal static Uri UrlBase => new Uri(Gw2WebApiClient.UrlBase, "v2/");

        private readonly IAccountClient account;
        private readonly IAchievementsClient achievements;
        private readonly IBackstoryClient backstory;
        private readonly IBuildClient build;
        private readonly ICharactersClient characters;
        private readonly IColorsClient colors;
        private readonly ICommerceClient commerce;
        private readonly IContinentsClient continents;
        private readonly ICreateSubtokenClient createSubtoken;
        private readonly ICurrenciesClient currencies;
        private readonly IDailyCraftingClient dailyCrafting;
        private readonly IDungeonsClient dungeons;
        private readonly IEmblemClient emblem;
        private readonly IFilesClient files;
        private readonly IFinishersClient finishers;
        private readonly IGlidersClient gliders;
        private readonly IGuildClient guild;
        private readonly IHomeClient home;
        private readonly IItemsClient items;
        private readonly IItemstatsClient itemstats;
        private readonly ILegendsClient legends;
        private readonly IMapChestsClient mapChests;
        private readonly IMailCarriersClient mailCarriers;
        private readonly IMapsClient maps;
        private readonly IMasteriesClient masteries;
        private readonly IMaterialsClient materials;
        private readonly ITokenInfoClient tokenInfo;
        private readonly IWorldBossesClient worldBosses;

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiV2Client"/>.
        /// </summary>
        public Gw2WebApiV2Client() : this(new Connection()) { }

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiV2Client"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="NullReferenceException"><paramref name="connection"/> is <c>null</c>.</exception>
        public Gw2WebApiV2Client(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.account = new AccountClient(connection);
            this.achievements = new AchievementsClient(connection);
            this.backstory = new BackstoryClient(connection);
            this.build = new BuildClient(connection);
            this.characters = new CharactersClient(connection);
            this.colors = new ColorsClient(connection);
            this.commerce = new CommerceClient(connection);
            this.continents = new ContinentsClient(connection);
            this.createSubtoken = new CreateSubtokenClient(connection);
            this.currencies = new CurrenciesClient(connection);
            this.dailyCrafting = new DailyCraftingClient(connection);
            this.dungeons = new DungeonsClient(connection);
            this.emblem = new EmblemClient(connection);
            this.files = new FilesClient(connection);
            this.finishers = new FinishersClient(connection);
            this.gliders = new GlidersClient(connection);
            this.guild = new GuildClient(connection);
            this.home = new HomeClient(connection);
            this.items = new ItemsClient(connection);
            this.itemstats = new ItemstatsClient(connection);
            this.legends = new LegendsClient(connection);
            this.mailCarriers = new MailCarriersClient(connection);
            this.mapChests = new MapChestsClient(connection);
            this.maps = new MapsClient(connection);
            this.masteries = new MasteriesClient(connection);
            this.materials = new MaterialsClient(connection);
            this.tokenInfo = new TokenInfoClient(connection);
            this.worldBosses = new WorldBossesClient(connection);
        }

        /// <inheritdoc />
        public IConnection Connection { get; private set; }

        /// <inheritdoc />
        public virtual IAccountClient Account => this.account;

        /// <inheritdoc />
        public virtual IAchievementsClient Achievements => this.achievements;

        /// <inheritdoc />
        public virtual IBackstoryClient Backstory => this.backstory;

        /// <inheritdoc />
        public virtual IBuildClient Build => this.build;

        /// <inheritdoc />
        public virtual ICharactersClient Characters => this.characters;

        /// <inheritdoc />
        public virtual IColorsClient Colors => this.colors;

        /// <inheritdoc />
        public virtual ICommerceClient Commerce => this.commerce;

        /// <inheritdoc />
        public virtual IContinentsClient Continents => this.continents;

        /// <inheritdoc />
        public virtual ICreateSubtokenClient CreateSubtoken => this.createSubtoken;

        /// <inheritdoc />
        public virtual ICurrenciesClient Currencies => this.currencies;

        /// <inheritdoc />
        public virtual IDailyCraftingClient DailyCrafting => this.dailyCrafting;

        /// <inheritdoc />
        public virtual IDungeonsClient Dungeons => this.dungeons;

        /// <inheritdoc />
        public virtual IEmblemClient Emblem => this.emblem;

        /// <inheritdoc />
        public virtual IFilesClient Files => this.files;

        /// <inheritdoc />
        public virtual IFinishersClient Finishers => this.finishers;

        /// <inheritdoc />
        public virtual IGlidersClient Gliders => this.gliders;

        /// <inheritdoc />
        public virtual IGuildClient Guild => this.guild;

        /// <inheritdoc />
        public virtual IHomeClient Home => this.home;

        /// <inheritdoc />
        public virtual IItemsClient Items => this.items;

        /// <inheritdoc />
        public virtual IItemstatsClient Itemstats => this.itemstats;

        /// <inheritdoc />
        public virtual ILegendsClient Legends => this.legends;

        /// <inheritdoc />
        public virtual IMailCarriersClient MailCarriers => this.mailCarriers;

        /// <inheritdoc />
        public virtual IMapChestsClient MapChests => this.mapChests;

        /// <inheritdoc />
        public virtual IMapsClient Maps => this.maps;

        /// <inheritdoc />
        public virtual IMasteriesClient Masteries => this.masteries;

        /// <inheritdoc />
        public virtual IMaterialsClient Materials => this.materials;

        /// <inheritdoc />
        public virtual ITokenInfoClient TokenInfo => this.tokenInfo;

        /// <inheritdoc />
        public virtual IWorldBossesClient WorldBosses => this.worldBosses;
    }
}
