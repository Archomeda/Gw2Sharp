using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 trait chat link.
    /// </summary>
    public class TraitChatLink : Gw2ChatLink<TraitChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Trait;

        /// <summary>
        /// The trait id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Traits"/>.
        /// </summary>
        public int TraitId
        {
            get => this.data.TraitId;
            set => this.data.TraitId = (ushort)value;
        }
    }
}
