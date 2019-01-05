namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An item flag.
    /// </summary>
    public enum ItemFlag
    {
        /// <summary>
        /// Unknown flag.
        /// </summary>
        Unknown,

        /// <summary>
        /// The item account binds on use.
        /// </summary>
        AccountBindOnUse,

        /// <summary>
        /// The item account binds on acquire.
        /// </summary>
        AccountBound,

        /// <summary>
        /// The item is attuned.
        /// </summary>
        Attuned,

        /// <summary>
        /// The item supports bulk consuming.
        /// </summary>
        BulkConsume,

        /// <summary>
        /// The item has a warning prompt upon deletion.
        /// </summary>
        DeleteWarning,

        /// <summary>
        /// The item has the suffix of upgrade components hidden.
        /// </summary>
        HideSuffix,

        /// <summary>
        /// The item is infused.
        /// </summary>
        Infused,

        /// <summary>
        /// The item is for monsters only.
        /// </summary>
        MonsterOnly,

        /// <summary>
        /// The item cannot be used in the mystic forge.
        /// </summary>
        NoMysticForge,

        /// <summary>
        /// The item cannot be salvaged.
        /// </summary>
        NoSalvage,

        /// <summary>
        /// The item cannot be sold to a vendor.
        /// </summary>
        NoSell,

        /// <summary>
        /// The item is not upgradeable.
        /// </summary>
        NotUpgradeable,

        /// <summary>
        /// The item is not usable underwater.
        /// </summary>
        NoUnderwater,

        /// <summary>
        /// The item soulbinds on acquire.
        /// </summary>
        SoulbindOnAcquire,

        /// <summary>
        /// The item soulbinds on use.
        /// </summary>
        SoulBindOnUse,

        /// <summary>
        /// The item is a tonic.
        /// </summary>
        Tonic,

        /// <summary>
        /// The item is unique.
        /// </summary>
        Unique
    }
}
