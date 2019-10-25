using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 skill chat link.
    /// </summary>
    public class SkillChatLink : Gw2ChatLink<SkillChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Skill;

        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int SkillId
        {
            get => this.data.SkillId;
            set => this.data.SkillId = (ushort)value;
        }
    }
}
