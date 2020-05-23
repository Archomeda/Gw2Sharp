using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 outfit chat link.
    /// </summary>
    public sealed class OutfitChatLink : Gw2ChatLink<OutfitChatLinkStruct>, IEquatable<OutfitChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Outfit;

        /// <summary>
        /// The outfit id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Outfits"/>.
        /// </summary>
        public int OutfitId
        {
            get => (int)this.data.OutfitId;
            set => this.data.OutfitId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is OutfitChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(OutfitChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.OutfitId == other.OutfitId;

        /// <inheritdoc />
        public override int GetHashCode() =>
            HashCode.Combine(this.Type, this.OutfitId);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="OutfitChatLink"/>.</param>
        /// <param name="right">The second <see cref="OutfitChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(OutfitChatLink left, OutfitChatLink right) =>
            EqualityComparer<OutfitChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="OutfitChatLink"/>.</param>
        /// <param name="right">The second <see cref="OutfitChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(OutfitChatLink left, OutfitChatLink right) =>
            !(left == right);

        #endregion
    }
}
