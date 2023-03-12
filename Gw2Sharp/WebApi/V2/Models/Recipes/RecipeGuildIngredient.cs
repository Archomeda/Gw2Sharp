using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a recipe ingredient from the guild.
    /// </summary>
    [Obsolete("Deprecated since 2021-09-28. Use RecipeIngredient instead. This will be removed from Gw2Sharp starting from version 2.0.")]
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
