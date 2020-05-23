using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 NPC text chat link.
    /// </summary>
    public sealed class NpcTextChatLink : Gw2ChatLink<NpcTextChatLinkStruct>, IEquatable<NpcTextChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.NpcText;

        /// <summary>
        /// The string id.
        /// </summary>
        public int StringId
        {
            get => (int)this.data.StringId;
            set => this.data.StringId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is NpcTextChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(NpcTextChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.StringId == other.StringId;

        /// <inheritdoc />
        public override int GetHashCode() =>
            HashCode.Combine(this.Type, this.StringId);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="NpcTextChatLink"/>.</param>
        /// <param name="right">The second <see cref="NpcTextChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NpcTextChatLink left, NpcTextChatLink right) =>
            EqualityComparer<NpcTextChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="NpcTextChatLink"/>.</param>
        /// <param name="right">The second <see cref="NpcTextChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NpcTextChatLink left, NpcTextChatLink right) =>
            !(left == right);

        #endregion
    }
}
