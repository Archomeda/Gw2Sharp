namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The guild upgrade type.
    /// </summary>
    public enum GuildUpgradeType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Mine capacity upgrade type.
        /// </summary>
        AccumulatingCurrency,

        /// <summary>
        /// Guild bank upgrade type.
        /// </summary>
        BankBag,

        /// <summary>
        /// Permanent guild buff type.
        /// </summary>
        Boost,

        /// <summary>
        /// WvW tactic type.
        /// </summary>
        Claimable,

        /// <summary>
        /// Consumable (e.g. banners and guild siege) type.
        /// </summary>
        Consumable,

        /// <summary>
        /// Decoration type.
        /// </summary>
        Decoration,

        /// <summary>
        /// Claiming guild hall type.
        /// </summary>
        GuildHall,

        /// <summary>
        /// Expedition type.
        /// </summary>
        GuildHallExpedition,

        /// <summary>
        /// Guild Initiative type.
        /// </summary>
        Hub,

        /// <summary>
        /// Permanent unlock type.
        /// </summary>
        Unlock,

        /// <summary>
        /// Queue type.
        /// </summary>
        Queue,
    }
}
