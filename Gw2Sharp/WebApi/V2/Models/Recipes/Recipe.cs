using System;
using System.Collections.Generic;
using System.Linq;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    public class Recipe : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The recipe id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The recipe type.
        /// </summary>
        public ApiEnum<RecipeType> Type { get; set; } = new ApiEnum<RecipeType>();

        /// <summary>
        /// The output item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int OutputItemId { get; set; }

        /// <summary>
        /// The number of output items.
        /// </summary>
        public int OutputItemCount { get; set; }

        /// <summary>
        /// The time to craft in milliseconds.
        /// </summary>
        public int TimeToCraftMs { get; set; }

        /// <summary>
        /// The minimum required rating to use this recipe.
        /// </summary>
        public int MinRating { get; set; }

        /// <summary>
        /// The chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The crafting disciplines that can use this recipe.
        /// </summary>
        public ApiFlags<CraftingDisciplineType> Disciplines { get; set; } = new ApiFlags<CraftingDisciplineType>();

        /// <summary>
        /// The recipe flags.
        /// </summary>
        public ApiFlags<RecipeFlag> Flags { get; set; } = new ApiFlags<RecipeFlag>();

        /// <summary>
        /// The recipe ingredients.
        /// </summary>
        public IReadOnlyList<RecipeIngredient> Ingredients { get; set; } = Array.Empty<RecipeIngredient>();

        /// <summary>
        /// The recipe ingredients from the guild.
        /// If the recipe doesn't require any guild ingredients, this value is <see langword="null"/>.
        /// <para/>
        /// This property has been moved into <see cref="Ingredients"/> started with schema version 2022-03.09T02:00:00.000Z.
        /// Gw2Sharp v1.x has roll-forward support, but this will be removed starting with v2.0.
        /// </summary>
        [Obsolete("Deprecated since schema version 2022-03-09T02:00:00.000Z. Use Ingredients and filter by Guild type instead. This will be removed from Gw2Sharp starting from version 2.0.")]
        public IReadOnlyList<RecipeGuildIngredient>? GuildIngredients => this.Ingredients
            .Where(x => x.Type.Value == RecipeIngredientType.GuildUpgrade)
            .Select(x => new RecipeGuildIngredient { UpgradeId = x.Id, Count = x.Count })
            .ToList();

        /// <summary>
        /// The output guild upgrade id.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// If the recipe doesn't output any guild upgrade, this value is <see langword="null"/>.
        /// </summary>
        public int OutputUpgradeId { get; set; }
    }
}
