using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 skill chat link.
    /// </summary>
    public sealed class SkillChatLink : Gw2ChatLink<SkillChatLinkStruct>, IEquatable<SkillChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Skill;

        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int SkillId
        {
            get => (int)this.data.SkillId;
            set => this.data.SkillId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is SkillChatLink && this.Equals((SkillChatLink)obj);

        /// <inheritdoc />
        public bool Equals(SkillChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.SkillId == other.SkillId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 159058432;
            hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.SkillId.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="SkillChatLink"/>.</param>
        /// <param name="right">The second <see cref="SkillChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(SkillChatLink left, SkillChatLink right) =>
            EqualityComparer<SkillChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="SkillChatLink"/>.</param>
        /// <param name="right">The second <see cref="SkillChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(SkillChatLink left, SkillChatLink right) =>
            !(left == right);

        #endregion
    }
}
