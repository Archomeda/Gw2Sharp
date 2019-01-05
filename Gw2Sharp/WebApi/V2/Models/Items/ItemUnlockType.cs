namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The item unlock type.
    /// </summary>
    public enum ItemUnlockType
    {
        /// <summary>
        /// Unknown unlock type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Bag slot unlock type.
        /// </summary>
        BagSlot,

        /// <summary>
        /// Bank tab unlock type.
        /// </summary>
        BankTab,

        /// <summary>
        /// Storage expander unlock type.
        /// </summary>
        CollectibleCapacity,

        /// <summary>
        /// Finshers, collection, etc. unlock type.
        /// </summary>
        Content,

        /// <summary>
        /// Crafting recipe unlock type.
        /// </summary>
        CraftingRecipe,

        /// <summary>
        /// Dye unlock type.
        /// </summary>
        Dye,

        /// <summary>
        /// Outfit unlock type.
        /// </summary>
        Outfit,

        /// <summary>
        /// Glider skin unlock type.
        /// </summary>
        GliderSkin,

        /// <summary>
        /// PvP mist champion unlock type.
        /// </summary>
        Champion,

        /// <summary>
        /// Random guaranteed wardrobe unlock type.
        /// </summary>
        RandomUlock
    }
}
