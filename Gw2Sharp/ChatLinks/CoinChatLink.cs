using Gw2Sharp.ChatLinks.Structs;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 coin chat link.
    /// </summary>
    public class CoinChatLink : Gw2ChatLink<CoinChatLinkStruct>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Coin;

        /// <summary>
        /// The number of coins in copper.
        /// </summary>
        public int Coins
        {
            get => this.data.Coins;
            set => this.data.Coins = value;
        }
    }
}
