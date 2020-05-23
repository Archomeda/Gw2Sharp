using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 WvW objective chat link.
    /// </summary>
    public sealed class WvwObjectiveChatLink : Gw2ChatLink<WvwObjectiveChatLinkStruct>, IEquatable<WvwObjectiveChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.WvwObjective;

        /// <summary>
        /// The objective id.
        /// Combined with <see cref="MapId"/>, this can be resolved against <see cref="IWvwClient.Objectives"/>.
        /// </summary>
        public int ObjectiveId
        {
            get => (int)this.data.ObjectiveId;
            set => this.data.ObjectiveId = (uint)value;
        }

        /// <summary>
        /// The map id.
        /// Combined with <see cref="ObjectiveId"/>, this can be resolved against <see cref="IWvwClient.Objectives"/>.
        /// </summary>
        public int MapId
        {
            get => (int)this.data.MapId;
            set => this.data.MapId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is WvwObjectiveChatLink link &&
                this.Type == link.Type &&
                this.ObjectiveId == link.ObjectiveId &&
                this.MapId == link.MapId;
        }

        /// <inheritdoc />
        public bool Equals(WvwObjectiveChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.ObjectiveId == other.ObjectiveId &&
            this.MapId == other.MapId;

        /// <inheritdoc />
        public override int GetHashCode() =>
            HashCode.Combine(this.Type, this.ObjectiveId, this.MapId);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="WvwObjectiveChatLink"/>.</param>
        /// <param name="right">The second <see cref="WvwObjectiveChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(WvwObjectiveChatLink left, WvwObjectiveChatLink right) =>
            EqualityComparer<WvwObjectiveChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="WvwObjectiveChatLink"/>.</param>
        /// <param name="right">The second <see cref="WvwObjectiveChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(WvwObjectiveChatLink left, WvwObjectiveChatLink right) =>
            !(left == right);

        #endregion
    }
}
