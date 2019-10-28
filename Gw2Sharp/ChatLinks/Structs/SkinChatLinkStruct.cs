using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 skin chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SkinChatLinkStruct
    {
        /// <summary>
        /// The skin id.
        /// </summary>
        [FieldOffset(0)]
        public uint SkinId;
    }
}
