using System.Runtime.InteropServices;

#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace Gw2Sharp.ChatLinks.Internal
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
        public uint OutfitId;
    }
}
