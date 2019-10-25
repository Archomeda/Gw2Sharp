using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 item chat link (data).
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ItemChatLinkStructData
    {
        /// <summary>
        /// The item id.
        /// </summary>
        [FieldOffset(0)]
        public UInt24 ItemId;

        /// <summary>
        /// Padding.
        /// </summary>
        [FieldOffset(3)]
        public byte Padding;
    }
}
