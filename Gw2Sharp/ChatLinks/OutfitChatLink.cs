using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 outfit chat link.
    /// </summary>
    public class OutfitChatLink : Gw2ChatLink<OutfitChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Outfit;

        /// <summary>
        /// The outfit id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Outfits"/>.
        /// </summary>
        public int OutfitId
        {
            get => this.data.OutfitId;
            set => this.data.OutfitId = (ushort)value;
        }
    }
}
