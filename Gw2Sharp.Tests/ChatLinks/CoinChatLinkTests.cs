using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class CoinChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> CoinChatLinks => new[]
        {
            new object[] { "[&AQAAAAA=]", new CoinChatLink { Coins = 0 } },
            new object[] { "[&AQEAAAA=]", new CoinChatLink { Coins = 1 } },
            new object[] { "[&AdsnAAA=]", new CoinChatLink { Coins = 10203 } }
        };

        [Theory]
        [MemberData(nameof(CoinChatLinks))]
        public void CoinChatLinkStringTest(string expected, CoinChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(CoinChatLinks))]
        public void CoinChatLinkObjectTest(string chatLink, CoinChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new CoinChatLink { Coins = 1 };
            var chatLink2 = new CoinChatLink { Coins = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
