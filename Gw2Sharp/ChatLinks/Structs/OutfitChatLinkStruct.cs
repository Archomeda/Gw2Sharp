using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 outfit chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct OutfitChatLinkStruct
    {
        /// <summary>
        /// The outfit id.
        /// </summary>
        [FieldOffset(0)]
        public ushort OutfitId;
    }
}
