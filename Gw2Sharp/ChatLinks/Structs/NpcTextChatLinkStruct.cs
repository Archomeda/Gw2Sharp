using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 NPC text chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct NpcTextChatLinkStruct
    {
        /// <summary>
        /// The string id.
        /// </summary>
        [FieldOffset(0)]
        public ushort StringId;
    }
}
