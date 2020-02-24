using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 trait chat link.
    /// </summary>
    public sealed class TraitChatLink : Gw2ChatLink<TraitChatLinkStruct>, IEquatable<TraitChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Trait;

        /// <summary>
        /// The trait id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Traits"/>.
        /// </summary>
        public int TraitId
        {
            get => (int)this.data.TraitId;
            set => this.data.TraitId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is TraitChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(TraitChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.TraitId == other.TraitId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1578337189;
                hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.TraitId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="TraitChatLink"/>.</param>
        /// <param name="right">The second <see cref="TraitChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(TraitChatLink left, TraitChatLink right) =>
            EqualityComparer<TraitChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="TraitChatLink"/>.</param>
        /// <param name="right">The second <see cref="TraitChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(TraitChatLink left, TraitChatLink right) =>
            !(left == right);

        #endregion
    }
}
