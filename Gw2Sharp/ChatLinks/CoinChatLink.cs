using System;
using System.Collections.Generic;
using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 coin chat link.
    /// </summary>
    public sealed class CoinChatLink : Gw2ChatLink<CoinChatLinkStruct>, IEquatable<CoinChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Coin;

        /// <summary>
        /// The number of coins in copper.
        /// </summary>
        public int Coins
        {
            get => (int)this.data.Coins;
            set => this.data.Coins = (uint)value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is CoinChatLink && this.Equals((CoinChatLink)obj);

        /// <inheritdoc />
        public bool Equals(CoinChatLink other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.Coins == other.Coins;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = -1373618686;
            hashCode = (hashCode * -1521134295) + this.Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.Coins.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="CoinChatLink"/>.</param>
        /// <param name="right">The second <see cref="CoinChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CoinChatLink left, CoinChatLink right) =>
            EqualityComparer<CoinChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="CoinChatLink"/>.</param>
        /// <param name="right">The second <see cref="CoinChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CoinChatLink left, CoinChatLink right) =>
            !(left == right);

        #endregion
    }
}
