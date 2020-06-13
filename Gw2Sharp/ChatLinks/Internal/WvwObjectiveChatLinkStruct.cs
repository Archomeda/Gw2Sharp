using System.Runtime.InteropServices;

#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace Gw2Sharp.ChatLinks.Internal
{
    /// <summary>
    /// Represents a Guild Wars 2 point of interest chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WvwObjectiveChatLinkStruct
    {
        /// <summary>
        /// The objective id.
        /// </summary>
        [FieldOffset(0)]
        public uint ObjectiveId;

        /// <summary>
        /// The map id.
        /// </summary>
        [FieldOffset(4)]
        public uint MapId;
    }
}
