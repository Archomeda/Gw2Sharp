using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 point of interest chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PointOfInterestChatLinkStruct
    {
        /// <summary>
        /// The point of interest id.
        /// </summary>
        [FieldOffset(0)]
        public uint PointOfInterestId;
    }
}
