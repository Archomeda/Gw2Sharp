namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id endpoint.
    /// </summary>
    public interface ICharactersIdClient : IClient
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }

        /// <summary>
        /// Gets a character's backstory information.
        /// Requires scopes: account, characters.
        /// </summary>
        ICharactersIdBackstoryClient Backstory { get; }

        /// <summary>
        /// Gets a character's core information.
        /// Requires scopes: account, characters.
        /// </summary>
        ICharactersIdCoreClient Core { get; }

        /// <summary>
        /// Gets a character's crafting information.
        /// Requires scopes: account, characters.
        /// </summary>
        ICharactersIdCraftingClient Crafting { get; }

        /// <summary>
        /// Gets a character's equipment.
        /// Requires scopes: account, characters, and builds and/or inventories.
        /// </summary>
        ICharactersIdEquipmentClient Equipment { get; }

        /// <summary>
        /// Gets a character's hero points information.
        /// Requires scopes: account, characters, progression.
        /// </summary>
        ICharactersIdHeroPointsClient HeroPoints { get; }

        /// <summary>
        /// Gets a character's inventory.
        /// Requires scopes: account, characters, inventory.
        /// </summary>
        ICharactersIdInventoryClient Inventory { get; }

        /// <summary>
        /// Gets a character's learned recipes.
        /// Requires scopes: account, characters, inventories.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        ICharactersIdRecipesClient Recipes { get; }

        /// <summary>
        /// Gets a character's Super Adventure Box information.
        /// Requires scopes: account, characters, progression.
        /// </summary>
        ICharactersIdSabClient Sab { get; }

        /// <summary>
        /// Gets a character's skills.
        /// Requires scopes: account, builds, characters.
        /// </summary>
        ICharactersIdSkillsClient Skills { get; }

        /// <summary>
        /// Gets a character's specializations.
        /// Requires scopes: account, builds, characters.
        /// </summary>
        ICharactersIdSpecializationsClient Specializations { get; }

        /// <summary>
        /// Gets a character's training information.
        /// Requires scopes: account, characters, progression.
        /// </summary>
        ICharactersIdTrainingClient Training { get; }
    }
}
