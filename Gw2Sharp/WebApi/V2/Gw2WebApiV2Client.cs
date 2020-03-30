using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// A client for the Guild Wars 2 web API v2.
    /// </summary>
    public class Gw2WebApiV2Client : BaseClient, IGw2WebApiV2Client
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
        private readonly IEmotesClient emotes;
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
        private readonly IMinisClient minis;
        private readonly IMountsClient mounts;
        private readonly INoveltiesClient novelties;
        private readonly IOutfitsClient outfits;
        private readonly IPetsClient pets;
        private readonly IProfessionsClient professions;
        private readonly IPvpClient pvp;
        private readonly IQuaggansClient quaggans;
        private readonly IQuestsClient quests;
        private readonly IRacesClient races;
        private readonly IRaidsClient raids;
        private readonly IRecipesClient recipes;
        private readonly ISkillsClient skills;
        private readonly ISkinsClient skins;
        private readonly ISpecializationsClient specializations;
        private readonly ITokenInfoClient tokenInfo;
        private readonly IWorldBossesClient worldBosses;

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiV2Client"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal Gw2WebApiV2Client(IConnection connection, IGw2Client gw2Client)
            : base(connection, gw2Client)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (gw2Client == null)
                throw new ArgumentNullException(nameof(gw2Client));

            this.account = new AccountClient(connection, gw2Client);
            this.achievements = new AchievementsClient(connection, gw2Client);
            this.backstory = new BackstoryClient(connection, gw2Client);
            this.build = new BuildClient(connection, gw2Client);
            this.characters = new CharactersClient(connection, gw2Client);
            this.colors = new ColorsClient(connection, gw2Client);
            this.commerce = new CommerceClient(connection, gw2Client);
            this.continents = new ContinentsClient(connection, gw2Client);
            this.createSubtoken = new CreateSubtokenClient(connection, gw2Client);
            this.currencies = new CurrenciesClient(connection, gw2Client);
            this.dailyCrafting = new DailyCraftingClient(connection, gw2Client);
            this.dungeons = new DungeonsClient(connection, gw2Client);
            this.emblem = new EmblemClient(connection, gw2Client);
            this.emotes = new EmotesClient(connection, gw2Client);
            this.files = new FilesClient(connection, gw2Client);
            this.finishers = new FinishersClient(connection, gw2Client);
            this.gliders = new GlidersClient(connection, gw2Client);
            this.guild = new GuildClient(connection, gw2Client);
            this.home = new HomeClient(connection, gw2Client);
            this.items = new ItemsClient(connection, gw2Client);
            this.itemstats = new ItemstatsClient(connection, gw2Client);
            this.legends = new LegendsClient(connection, gw2Client);
            this.mailCarriers = new MailCarriersClient(connection, gw2Client);
            this.mapChests = new MapChestsClient(connection, gw2Client);
            this.maps = new MapsClient(connection, gw2Client);
            this.masteries = new MasteriesClient(connection, gw2Client);
            this.materials = new MaterialsClient(connection, gw2Client);
            this.minis = new MinisClient(connection, gw2Client);
            this.mounts = new MountsClient(connection, gw2Client);
            this.novelties = new NoveltiesClient(connection, gw2Client);
            this.outfits = new OutfitsClient(connection, gw2Client);
            this.pets = new PetsClient(connection, gw2Client);
            this.professions = new ProfessionsClient(connection, gw2Client);
            this.pvp = new PvpClient(connection, gw2Client);
            this.quaggans = new QuaggansClient(connection, gw2Client);
            this.quests = new QuestsClient(connection, gw2Client);
            this.races = new RacesClient(connection, gw2Client);
            this.raids = new RaidsClient(connection, gw2Client);
            this.recipes = new RecipesClient(connection, gw2Client);
            this.skills = new SkillsClient(connection, gw2Client);
            this.skins = new SkinsClient(connection, gw2Client);
            this.specializations = new SpecializationsClient(connection, gw2Client);
            this.tokenInfo = new TokenInfoClient(connection, gw2Client);
            this.worldBosses = new WorldBossesClient(connection, gw2Client);
        }

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
        public virtual IEmotesClient Emotes => this.emotes;

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
        public virtual IMinisClient Minis => this.minis;

        /// <inheritdoc />
        public virtual IMountsClient Mounts => this.mounts;

        /// <inheritdoc />
        public virtual INoveltiesClient Novelties => this.novelties;

        /// <inheritdoc />
        public virtual IOutfitsClient Outfits => this.outfits;

        /// <inheritdoc />
        public virtual IPetsClient Pets => this.pets;

        /// <inheritdoc />
        public virtual IProfessionsClient Professions => this.professions;

        /// <inheritdoc />
        public virtual IPvpClient Pvp => this.pvp;

        /// <inheritdoc />
        public virtual IQuaggansClient Quaggans => this.quaggans;

        /// <inheritdoc />
        public virtual IQuestsClient Quests => this.quests;

        /// <inheritdoc />
        public virtual IRacesClient Races => this.races;

        /// <inheritdoc />
        public virtual IRaidsClient Raids => this.raids;

        /// <inheritdoc />
        public virtual IRecipesClient Recipes => this.recipes;

        /// <inheritdoc />
        public virtual ISkillsClient Skills => this.skills;

        /// <inheritdoc />
        public virtual ISkinsClient Skins => this.skins;

        /// <inheritdoc />
        public virtual ISpecializationsClient Specializations => this.specializations;

        /// <inheritdoc />
        public virtual ITokenInfoClient TokenInfo => this.tokenInfo;

        /// <inheritdoc />
        public virtual IWorldBossesClient WorldBosses => this.worldBosses;
    }
}
