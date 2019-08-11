using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a recipe ingredient from the guild.
    /// </summary>
    public class RecipeGuildIngredient
    {
        /// <summary>
        /// The guild upgrade id.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public int UpgradeId { get; set; }

        /// <summary>
        /// The number of items.
        /// </summary>
        public int Count { get; set; }
    }
}
