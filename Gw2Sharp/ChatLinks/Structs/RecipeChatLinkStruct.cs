using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 recipe chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct RecipeChatLinkStruct
    {
        /// <summary>
        /// The recipe id.
        /// </summary>
        [FieldOffset(0)]
        public uint RecipeId;
    }
}
