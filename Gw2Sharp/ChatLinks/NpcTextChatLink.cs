using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 NPC text chat link.
    /// </summary>
    public class NpcTextChatLink : Gw2ChatLink<NpcTextChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.NpcText;

        /// <summary>
        /// The string id.
        /// </summary>
        public int StringId
        {
            get => this.data.StringId;
            set => this.data.StringId = (ushort)value;
        }
    }
}
