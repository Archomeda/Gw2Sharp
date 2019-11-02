using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 skill chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SkillChatLinkStruct
    {
        /// <summary>
        /// The skill id.
        /// </summary>
        [FieldOffset(0)]
        public uint SkillId;
    }
}
