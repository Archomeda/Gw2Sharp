using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 point of interest chat link.
    /// </summary>
    public sealed class PointOfInterestChatLink : Gw2ChatLink<PointOfInterestChatLinkStruct>, IEquatable<PointOfInterestChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.PointOfInterest;

        /// <summary>
        /// The point of interest id.
        /// </summary>
        public int PointOfInterestId
        {
            get => (int)this.data.PointOfInterestId;
            set => this.data.PointOfInterestId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is PointOfInterestChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(PointOfInterestChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.PointOfInterestId == other.PointOfInterestId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 2118947312;
            hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.PointOfInterestId.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="PointOfInterestChatLink"/>.</param>
        /// <param name="right">The second <see cref="PointOfInterestChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(PointOfInterestChatLink left, PointOfInterestChatLink right) =>
            EqualityComparer<PointOfInterestChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="PointOfInterestChatLink"/>.</param>
        /// <param name="right">The second <see cref="PointOfInterestChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(PointOfInterestChatLink left, PointOfInterestChatLink right) =>
            !(left == right);

        #endregion
    }
}
