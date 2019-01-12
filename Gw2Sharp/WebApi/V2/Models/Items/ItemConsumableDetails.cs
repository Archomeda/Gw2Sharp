using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a consumable item.
    /// </summary>
    public class ItemConsumableDetails
    {
        /// <summary>
        /// The consumable item type.
        /// </summary>
        public ApiEnum<ItemConsumableType> Type { get; set; } = new ApiEnum<ItemConsumableType>();

        /// <summary>
        /// The item description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The item duration in milliseconds.
        /// If the item does not have a duration, this value is <c>null</c>.
        /// </summary>
        public int? DurationMs { get; set; }

        /// <summary>
        /// The item unlock type for unlock consumables, check <see cref="Type"/>.
        /// If the item is not an unlock consumable, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<ItemUnlockType>? UnlockType { get; set; }

        /// <summary>
        /// The dye id for dye unlocks, check <see cref="UnlockType"/>.
        /// If the item is not a dye unlock, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        public int? ColorId { get; set; }

        /// <summary>
        /// The recipe id for recipe unlocks, check <see cref="UnlockType"/>.
        /// If the item is not a recipe unlock, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public int? RecipeId { get; set; }

        /// <summary>
        /// The guild upgrade id for generic unlocks, check <see cref="UnlockType"/>.
        /// If the item is not a generic unlock nor a guild upgrade item, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public int? GuildUpgradeId { get; set; }

        /// <summary>
        /// The number of stacks of the effect is applied by the item.
        /// If the item does not apply an effect, this value is <c>null</c>.
        /// </summary>
        public int? ApplyCount { get; set; }

        /// <summary>
        /// The effect tyype name of the item.
        /// If the item does not apply an effect, this value is <c>null</c>.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The list of skin ids which the item unlocks.
        /// If the item does not unlock skins, this value is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public IReadOnlyList<int>? Skins { get; set; }
    }
}
