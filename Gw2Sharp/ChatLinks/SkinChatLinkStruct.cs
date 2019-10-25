using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 skin chat link.
    /// </summary>
    public class SkinChatLink : Gw2ChatLink<SkinChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Skin;

        /// <summary>
        /// The skin id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int SkinId
        {
            get => this.data.SkinId;
            set => this.data.SkinId = (ushort)value;
        }
    }
}
