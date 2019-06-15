using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id endpoint.
    /// </summary>
    [EndpointPath("characters/:id")]
    public class CharactersIdClient : BaseClient, ICharactersIdClient
    {
        private readonly string characterName;
        private readonly ICharactersIdBackstoryClient backstory;
        private readonly ICharactersIdCoreClient core;
        private readonly ICharactersIdCraftingClient crafting;
        private readonly ICharactersIdEquipmentClient equipment;
        private readonly ICharactersIdHeroPointsClient heroPoints;
        private readonly ICharactersIdInventoryClient inventory;
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
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdClient(IConnection connection, string characterName) :
            base(connection)
        {
            this.characterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
            this.backstory = new CharactersIdBackstoryClient(connection, characterName);
            this.core = new CharactersIdCoreClient(connection, characterName);
            this.crafting = new CharactersIdCraftingClient(connection, characterName);
            this.equipment = new CharactersIdEquipmentClient(connection, characterName);
            this.heroPoints = new CharactersIdHeroPointsClient(connection, characterName);
            this.inventory = new CharactersIdInventoryClient(connection, characterName);
            this.recipes = new CharactersIdRecipesClient(connection, characterName);
            this.sab = new CharactersIdSabClient(connection, characterName);
            this.skills = new CharactersIdSkillsClient(connection, characterName);
            this.specializations = new CharactersIdSpecializationsClient(connection, characterName);
            this.training = new CharactersIdTrainingClient(connection, characterName);
        }

        /// <inheritdoc />
        public virtual string CharacterName => this.characterName;

        /// <inheritdoc />
        public virtual ICharactersIdBackstoryClient Backstory => this.backstory;

        /// <inheritdoc />
        public virtual ICharactersIdCoreClient Core => this.core;

        /// <inheritdoc />
        public virtual ICharactersIdCraftingClient Crafting => this.crafting;

        /// <inheritdoc />
        public virtual ICharactersIdEquipmentClient Equipment => this.equipment;

        /// <inheritdoc />
        public virtual ICharactersIdHeroPointsClient HeroPoints => this.heroPoints;

        /// <inheritdoc />
        public virtual ICharactersIdInventoryClient Inventory => this.inventory;

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
