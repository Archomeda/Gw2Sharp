using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 item chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ItemChatLinkStruct
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
        /// Additional data flag.
        /// </summary>
        [FieldOffset(4)]
        public ItemChatLinkStructAdditionalData AdditionalDataFlag;

        /// <summary>
        /// Additional data.
        /// </summary>
        [FieldOffset(5)]
        public fixed uint AdditionalData[3];
    }
}
