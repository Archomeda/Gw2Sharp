using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a recipe ingredient.
    /// </summary>
    public class RecipeIngredient
    {
        /// <inheritdoc cref="Id"/>
        [Obsolete("Deprecated since schema version 2022-03-09T02:00:00.000Z. Use Id instead. This will be removed from Gw2Sharp starting from version 2.0.")]
        public int ItemId
        {
            get => this.Id;
            set => this.Id = value;
        }

        /// <summary>
        /// The ingredient id.
        /// Can be resolved against:
        /// <list type="bullet">
        /// <item><see cref="IGw2WebApiV2Client.Items"/> when <see cref="Type"/> is <see cref="RecipeIngredientType.Item"/></item>
        /// <item><see cref="IGuildClient.Upgrades"/> when <see cref="Type"/> is <see cref="RecipeIngredientType.GuildUpgrade"/></item>
        /// <item><see cref="IGw2WebApiV2Client.Currencies"/> when <see cref="Type"/> is <see cref="RecipeIngredientType.Currency"/></item>
        /// </list>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ingredient count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The ingredient type.
        /// </summary>
        public ApiEnum<RecipeIngredientType> Type { get; set; } = new();
    }
}
