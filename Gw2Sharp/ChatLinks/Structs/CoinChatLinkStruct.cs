using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 coin chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CoinChatLinkStruct
    {
        /// <summary>
        /// The number of coins in copper.
        /// </summary>
        [FieldOffset(0)]
        public uint Coins;
    }
}
