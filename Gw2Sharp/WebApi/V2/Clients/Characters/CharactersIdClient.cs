using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id endpoint.
    /// </summary>
    [EndpointPath("characters/:id")]
    public class CharactersIdClient : BaseClient, ICharactersIdClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdClient"/> that is used for the API v2 characters id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name that's used for all character requests.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdClient(IConnection connection, string characterName) :
            base(connection)
        {
            this.CharacterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
            this.Backstory = new CharactersIdBackstoryClient(connection, characterName);
            this.Core = new CharactersIdCoreClient(connection, characterName);
            this.Crafting = new CharactersIdCraftingClient(connection, characterName);
            this.Equipment = new CharactersIdEquipmentClient(connection, characterName);
            this.HeroPoints = new CharactersIdHeroPointsClient(connection, characterName);
            this.Inventory = new CharactersIdInventoryClient(connection, characterName);
            this.Recipes = new CharactersIdRecipesClient(connection, characterName);
            this.Sab = new CharactersIdSabClient(connection, characterName);
            this.Skills = new CharactersIdSkillsClient(connection, characterName);
            this.Specializations = new CharactersIdSpecializationsClient(connection, characterName);
            this.Training = new CharactersIdTrainingClient(connection, characterName);
        }

        /// <inheritdoc />
        public virtual string CharacterName { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdBackstoryClient Backstory { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdCoreClient Core { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdCraftingClient Crafting { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdEquipmentClient Equipment { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdHeroPointsClient HeroPoints { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdInventoryClient Inventory { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdRecipesClient Recipes { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdSabClient Sab { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdSkillsClient Skills { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdSpecializationsClient Specializations { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersIdTrainingClient Training { get; protected set; }
    }
}
