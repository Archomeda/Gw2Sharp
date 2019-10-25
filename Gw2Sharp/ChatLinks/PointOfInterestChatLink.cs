using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 point of interest chat link.
    /// </summary>
    public class PointOfInterestChatLink : Gw2ChatLink<PointOfInterestChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.PointOfInterest;

        /// <summary>
        /// The point of interest id.
        /// </summary>
        public int OutfitId
        {
            get => this.data.PointOfInterestId;
            set => this.data.PointOfInterestId = (ushort)value;
        }
    }
}
