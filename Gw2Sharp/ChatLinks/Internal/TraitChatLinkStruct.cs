using System.Runtime.InteropServices;

#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace Gw2Sharp.ChatLinks.Internal
{
    /// <summary>
    /// Represents a Guild Wars 2 trait chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct TraitChatLinkStruct
    {
        /// <summary>
        /// The trait id.
        /// </summary>
        [FieldOffset(0)]
        public uint TraitId;
    }
}
