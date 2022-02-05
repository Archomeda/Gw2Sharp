#pragma warning disable CA1028 // Enum Storage should be Int32

namespace Gw2Sharp.Models
{
    /// <summary>
    /// Represents a mount.
    /// Used by Mumble Link.
    /// </summary>
    public enum MountType : byte
    {
        /// <summary>
        /// No mount.
        /// </summary>
        None,

        /// <summary>
        /// The jackal mount.
        /// </summary>
        Jackal,

        /// <summary>
        /// The griffon mount.
        /// </summary>
        Griffon,

        /// <summary>
        /// The springer mount.
        /// </summary>
        Springer,

        /// <summary>
        /// The skimmer mount.
        /// </summary>
        Skimmer,

        /// <summary>
        /// The raptor mount.
        /// </summary>
        Raptor,

        /// <summary>
        /// The roller beetle mount.
        /// </summary>
        RollerBeetle,

        /// <summary>
        /// The warclaw mount.
        /// </summary>
        Warclaw,

        /// <summary>
        /// The skyscale mount.
        /// </summary>
        Skyscale,

        /// <summary>
        /// The skiff.
        /// </summary>
        Skiff,

        /// <summary>
        /// The siege turtle mount.
        /// </summary>
        SiegeTurtle
    }
}
