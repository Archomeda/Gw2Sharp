using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 item chat link (main).
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ItemChatLinkStructMain
    {
        /// <summary>
        /// The quantity.
        /// </summary>
        [FieldOffset(0)]
        public byte Quantity;

        /// <summary>
        /// The item id.
        /// </summary>
        [FieldOffset(1)]
        public UInt24 ItemId;

        /// <summary>
        /// The extra item data.
        /// </summary>
        [FieldOffset(4)]
        public ItemChatLinkStructAdditionalData AdditionalData;
    }
}
