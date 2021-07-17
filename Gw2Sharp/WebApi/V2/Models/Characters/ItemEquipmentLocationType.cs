namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The item equipment location type.
    /// </summary>
    public enum ItemEquipmentLocationType
    {
        /// <summary>
        /// Unknown location type.
        /// </summary>
        Unknown,

        /// <summary>
        /// The equipped location type.
        /// </summary>
        Equipped,

        /// <summary>
        /// The armory location type.
        /// </summary>
        Armory,

        /// <summary>
        /// The equipped from legendary armory location type.
        /// </summary>
        EquippedFromLegendaryArmory,

        /// <summary>
        /// The legendary armory location type.
        /// </summary>
        LegendaryArmory
    }
}
