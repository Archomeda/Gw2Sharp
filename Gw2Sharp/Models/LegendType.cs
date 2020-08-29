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
        Legend1 = 1,

        /// <summary>
        /// Glint.
        /// </summary>
        Glint = Legend1,

        /// <summary>
        /// Shiro.
        /// </summary>
        Legend2 = 2,

        /// <summary>
        /// Glint.
        /// </summary>
        Shiro = Legend2,

        /// <summary>
        /// Jalis.
        /// </summary>
        Legend3 = 3,

        /// <summary>
        /// Jalis.
        /// </summary>
        Jalis = Legend3,

        /// <summary>
        /// Mallyx.
        /// </summary>
        Legend4 = 4,

        /// <summary>
        /// Mallyx.
        /// </summary>
        Mallyx = Legend4,

        /// <summary>
        /// Kalla.
        /// </summary>
        Legend5 = 5,

        /// <summary>
        /// Kalla.
        /// </summary>
        Kalla = Legend5,

        /// <summary>
        /// Ventari.
        /// </summary>
        Legend6 = 6,

        /// <summary>
        /// Ventari.
        /// </summary>
        Ventari = Legend6
    }
}
