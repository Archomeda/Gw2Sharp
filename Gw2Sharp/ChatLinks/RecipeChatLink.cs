using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 recipe chat link.
    /// </summary>
    public sealed class RecipeChatLink : Gw2ChatLink<RecipeChatLinkStruct>, IEquatable<RecipeChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Recipe;

        /// <summary>
        /// The recipe id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public int RecipeId
        {
            get => (int)this.data.RecipeId;
            set => this.data.RecipeId = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is RecipeChatLink && this.Equals((RecipeChatLink)obj);

        /// <inheritdoc />
        public bool Equals(RecipeChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.RecipeId == other.RecipeId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = -1409232777;
            hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.RecipeId.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="RecipeChatLink"/>.</param>
        /// <param name="right">The second <see cref="RecipeChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RecipeChatLink left, RecipeChatLink right) =>
            EqualityComparer<RecipeChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="RecipeChatLink"/>.</param>
        /// <param name="right">The second <see cref="RecipeChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RecipeChatLink left, RecipeChatLink right) =>
            !(left == right);

        #endregion
    }
}
