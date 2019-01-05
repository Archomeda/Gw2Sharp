using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an item.
    /// The item can be <see cref="ItemArmor"/>,
    /// <see cref="ItemBack"/>,
    /// <see cref="ItemBag"/>,
    /// <see cref="ItemConsumable"/>,
    /// <see cref="ItemCraftingMaterial"/>,
    /// <see cref="ItemContainer"/>,
    /// <see cref="ItemGathering"/>,
    /// <see cref="ItemGizmo"/>,
    /// <see cref="ItemMiniPet"/>,
    /// <see cref="ItemTool"/>,
    /// <see cref="ItemTrait"/>,
    /// <see cref="ItemTrinket"/>,
    /// <see cref="ItemTrophy"/>,
    /// <see cref="ItemUpgradeComponent"/> or
    /// <see cref="ItemWeapon"/>
    /// </summary>
    [CastableType(ItemType.Armor, typeof(ItemArmor))]
    [CastableType(ItemType.Back, typeof(ItemBack))]
    [CastableType(ItemType.Bag, typeof(ItemBag))]
    [CastableType(ItemType.Consumable, typeof(ItemConsumable))]
    [CastableType(ItemType.CraftingMaterial, typeof(ItemCraftingMaterial))]
    [CastableType(ItemType.Container, typeof(ItemContainer))]
    [CastableType(ItemType.Gathering, typeof(ItemGathering))]
    [CastableType(ItemType.Gizmo, typeof(ItemGizmo))]
    [CastableType(ItemType.MiniPet, typeof(ItemMiniPet))]
    [CastableType(ItemType.Tool, typeof(ItemTool))]
    [CastableType(ItemType.Trait, typeof(ItemTrait))]
    [CastableType(ItemType.Trinket, typeof(ItemTrinket))]
    [CastableType(ItemType.Trophy, typeof(ItemTrophy))]
    [CastableType(ItemType.UpgradeComponent, typeof(ItemUpgradeComponent))]
    [CastableType(ItemType.Weapon, typeof(ItemWeapon))]
    public class Item : IIdentifiable<int>, ICastableType<Item, ItemType>
    {
        /// <summary>
        /// The item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The item description.
        /// If the item does not have a description, this value is <c>null</c>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The item type.
        /// </summary>
        public ApiEnum<ItemType> Type { get; set; }

        /// <summary>
        /// The required minimum level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The item rarity.
        /// </summary>
        public ApiEnum<ItemRarity> Rarity { get; set; }

        /// <summary>
        /// The item vendor value.
        /// </summary>
        public int VendorValue { get; set; }

        /// <summary>
        /// The item default skin.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// If the item does not have a default skin, this value is <c>null</c>.
        /// </summary>
        public int? DefaultSkin { get; set; }

        /// <summary>
        /// The item game types.
        /// </summary>
        public IReadOnlyList<ApiEnum<ItemGameType>> GameTypes { get; set; }

        /// <summary>
        /// The item flags.
        /// </summary>
        public IReadOnlyList<ApiEnum<ItemFlag>> Flags { get; set; }

        /// <summary>
        /// The item restrictions.
        /// </summary>
        public IReadOnlyList<ApiEnum<ItemRestriction>> Restrictions { get; set; }

        /// <summary>
        /// The item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item chat link.
        /// </summary>
        public string ChatLink { get; set; }

        /// <summary>
        /// The item icon.
        /// </summary>
        public string Icon { get; set; }
    }
}
