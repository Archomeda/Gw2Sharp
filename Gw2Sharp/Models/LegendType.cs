#pragma warning disable CA1028 // Enum Storage should be Int32

namespace Gw2Sharp.Models
{
    /// <summary>
    /// Represents a legend.
    /// Used by chat links.
    /// </summary>
    public enum LegendType : byte
    {
        /// <summary>
        /// Glint.
        /// </summary>
        Legend1 = 14,

        /// <summary>
        /// Glint.
        /// </summary>
        Glint = Legend1,

        /// <summary>
        /// Shiro.
        /// </summary>
        Legend2 = 15,

        /// <summary>
        /// Glint.
        /// </summary>
        Shiro = Legend2,

        /// <summary>
        /// Jalis.
        /// </summary>
        Legend3 = 16,

        /// <summary>
        /// Jalis.
        /// </summary>
        Jalis = Legend3,

        /// <summary>
        /// Mallyx.
        /// </summary>
        Legend4 = 17,

        /// <summary>
        /// Mallyx.
        /// </summary>
        Mallyx = Legend4,

        /// <summary>
        /// Kalla.
        /// </summary>
        Legend5 = 18,

        /// <summary>
        /// Kalla.
        /// </summary>
        Kalla = Legend5,

        /// <summary>
        /// Ventari.
        /// </summary>
        Legend6 = 19,

        /// <summary>
        /// Ventari.
        /// </summary>
        Ventari = Legend6
    }
}
