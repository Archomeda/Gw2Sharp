using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id endpoint.
    /// </summary>
    [EndpointPath("characters/:id")]
    [EndpointPathSegment("id", 0)]
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class CharactersIdClient : BaseEndpointBlobClient<Character>, ICharactersIdClient
    {
        private readonly string characterName;
        private readonly ICharactersIdBackstoryClient backstory;
        private readonly ICharactersIdBuildTabsClient buildTabs;
        private readonly ICharactersIdCoreClient core;
        private readonly ICharactersIdCraftingClient crafting;
        private readonly ICharactersIdEquipmentClient equipment;
        private readonly ICharactersIdEquipmentTabsClient equipmentTabs;
        private readonly ICharactersIdHeroPointsClient heroPoints;
        private readonly ICharactersIdInventoryClient inventory;
        private readonly ICharactersIdQuestsClient quests;
        private readonly ICharactersIdRecipesClient recipes;
        private readonly ICharactersIdSabClient sab;
        private readonly ICharactersIdSkillsClient skills;
        private readonly ICharactersIdSpecializationsClient specializations;
        private readonly ICharactersIdTrainingClient training;

        /// <summary>
        /// Creates a new <see cref="CharactersIdClient"/> that is used for the API v2 characters id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name that's used for all character requests.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        protected internal CharactersIdClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        {
            this.characterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
            this.backstory = new CharactersIdBackstoryClient(connection, gw2Client, characterName);
            this.buildTabs = new CharactersIdBuildTabsClient(connection, gw2Client, characterName);
            this.core = new CharactersIdCoreClient(connection, gw2Client, characterName);
            this.crafting = new CharactersIdCraftingClient(connection, gw2Client, characterName);
            this.equipment = new CharactersIdEquipmentClient(connection, gw2Client, characterName);
            this.equipmentTabs = new CharactersIdEquipmentTabsClient(connection, gw2Client, characterName);
            this.heroPoints = new CharactersIdHeroPointsClient(connection, gw2Client, characterName);
            this.inventory = new CharactersIdInventoryClient(connection, gw2Client, characterName);
            this.quests = new CharactersIdQuestsClient(connection, gw2Client, characterName);
            this.recipes = new CharactersIdRecipesClient(connection, gw2Client, characterName);
            this.sab = new CharactersIdSabClient(connection, gw2Client, characterName);
            this.skills = new CharactersIdSkillsClient(connection, gw2Client, characterName);
            this.specializations = new CharactersIdSpecializationsClient(connection, gw2Client, characterName);
            this.training = new CharactersIdTrainingClient(connection, gw2Client, characterName);
        }

        /// <inheritdoc />
        public virtual string CharacterName => this.characterName;

        /// <inheritdoc />
        public virtual ICharactersIdBackstoryClient Backstory => this.backstory;

        /// <inheritdoc />
        public virtual ICharactersIdBuildTabsClient BuildTabs => this.buildTabs;

        /// <inheritdoc />
        public virtual ICharactersIdCoreClient Core => this.core;

        /// <inheritdoc />
        public virtual ICharactersIdCraftingClient Crafting => this.crafting;

        /// <inheritdoc />
        public virtual ICharactersIdEquipmentClient Equipment => this.equipment;

        /// <inheritdoc />
        public virtual ICharactersIdEquipmentTabsClient EquipmentTabs => this.equipmentTabs;

        /// <inheritdoc />
        public virtual ICharactersIdHeroPointsClient HeroPoints => this.heroPoints;

        /// <inheritdoc />
        public virtual ICharactersIdInventoryClient Inventory => this.inventory;

        /// <inheritdoc />
        public virtual ICharactersIdQuestsClient Quests => this.quests;

        /// <inheritdoc />
        public virtual ICharactersIdRecipesClient Recipes => this.recipes;

        /// <inheritdoc />
        public virtual ICharactersIdSabClient Sab => this.sab;

        /// <inheritdoc />
        public virtual ICharactersIdSkillsClient Skills => this.skills;

        /// <inheritdoc />
        public virtual ICharactersIdSpecializationsClient Specializations => this.specializations;

        /// <inheritdoc />
        public virtual ICharactersIdTrainingClient Training => this.training;
    }
}
