using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 skin chat link.
    /// </summary>
    public sealed class SkinChatLink : Gw2ChatLink<SkinChatLinkStruct>, IEquatable<SkinChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Skin;

        /// <summary>
        /// The skin id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int SkinId
        {
            get => (int)this.data.SkinId;
            set => this.data.SkinId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is SkinChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(SkinChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.SkinId == other.SkinId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 991712474;
                hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.SkinId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="SkinChatLink"/>.</param>
        /// <param name="right">The second <see cref="SkinChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(SkinChatLink left, SkinChatLink right) =>
            EqualityComparer<SkinChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="SkinChatLink"/>.</param>
        /// <param name="right">The second <see cref="SkinChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(SkinChatLink left, SkinChatLink right) =>
            !(left == right);

        #endregion
    }
}
