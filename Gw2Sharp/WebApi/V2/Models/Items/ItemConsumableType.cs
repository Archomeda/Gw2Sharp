namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The item consumable type.
    /// </summary>
    public enum ItemConsumableType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Appearance change consumable type.
        /// </summary>
        AppearanceChange,

        /// <summary>
        /// Alcohol consumable type.
        /// </summary>
        Booze,

        /// <summary>
        /// Contract NPC consumable type.
        /// </summary>
        ContractNpc,

        /// <summary>
        /// Food consumable type.
        /// </summary>
        Food,

        /// <summary>
        /// Generic consumable type.
        /// </summary>
        Generic,

        /// <summary>
        /// Halloween consumable type.
        /// </summary>
        Halloween,

        /// <summary>
        /// Consumable type for items that grant immediate effects.
        /// </summary>
        Immediate,

        /// <summary>
        /// Skin cosumable type.
        /// </summary>
        Transmutation,

        /// <summary>
        /// Unlock consumable type.
        /// </summary>
        Unlock,

        /// <summary>
        /// Upgrade removal consumable type.
        /// </summary>
        UpgradeRemoval,

        /// <summary>
        /// Utility consumable type.
        /// </summary>
        Utility,

        /// <summary>
        /// Teleport to friend consumable type.
        /// </summary>
        TeleportToFriend,

        /// <summary>
        /// Currency type.
        /// </summary>
        Currency,

        /// <summary>
        /// A randomized unlock type.
        /// </summary>
        RandomUnlock,

        /// <summary>
        /// A randomized mount unlock type.
        /// </summary>
        MountRandomUnlock
    }
}
