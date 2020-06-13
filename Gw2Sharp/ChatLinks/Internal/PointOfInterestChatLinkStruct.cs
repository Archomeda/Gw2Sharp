using System.Runtime.InteropServices;

#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace Gw2Sharp.ChatLinks.Internal
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
