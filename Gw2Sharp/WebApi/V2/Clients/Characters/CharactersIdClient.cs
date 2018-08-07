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
        public CharactersIdClient(IConnection connection, string characterName) : base(connection)
        {
            this.CharacterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
            this.Backstory = new CharactersBackstoryClient(connection, characterName);
            this.Core = new CharactersCoreClient(connection, characterName);
            this.Crafting = new CharactersCraftingClient(connection, characterName);
            this.Equipment = new CharactersEquipmentClient(connection, characterName);
            this.HeroPoints = new CharactersHeroPointsClient(connection, characterName);
            this.Inventory = new CharactersInventoryClient(connection, characterName);
            this.Recipes = new CharactersRecipesClient(connection, characterName);
            this.Sab = new CharactersSabClient(connection, characterName);
            this.Skills = new CharactersSkillsClient(connection, characterName);
            this.Specializations = new CharactersSpecializationsClient(connection, characterName);
            this.Training = new CharactersTrainingClient(connection, characterName);
        }

        /// <inheritdoc />
        public virtual string CharacterName { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersBackstoryClient Backstory { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersCoreClient Core { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersCraftingClient Crafting { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersEquipmentClient Equipment { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersHeroPointsClient HeroPoints { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersInventoryClient Inventory { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersRecipesClient Recipes { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersSabClient Sab { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersSkillsClient Skills { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersSpecializationsClient Specializations { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersTrainingClient Training { get; protected set; }
    }
}
