using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class OutfitChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> OutfitChatLinks => new[]
        {
            new object[] { "[&CwQAAAA=]", new OutfitChatLink { OutfitId = 4 } },
            new object[] { "[&CykAAAA=]", new OutfitChatLink { OutfitId = 41 } },
            new object[] { "[&C1AAAAA=]", new OutfitChatLink { OutfitId = 80 } }
        };

        [Theory]
        [MemberData(nameof(OutfitChatLinks))]
        public void OutfitChatLinkStringTest(string expected, OutfitChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(OutfitChatLinks))]
        public void OutfitChatLinkObjectTest(string chatLink, OutfitChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new OutfitChatLink { OutfitId = 1 };
            var chatLink2 = new OutfitChatLink { OutfitId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
