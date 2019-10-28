using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class TraitChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> TraitChatLinks => new[]
        {
            new object[] { "[&B/IDAAA=]", new TraitChatLink { TraitId = 1010 } },
            new object[] { "[&B3QHAAA=]", new TraitChatLink { TraitId = 1908 } },
            new object[] { "[&B9YHAAA=]", new TraitChatLink { TraitId = 2006 } }
        };

        [Theory]
        [MemberData(nameof(TraitChatLinks))]
        public void TraitChatLinkStringTest(string expected, TraitChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(TraitChatLinks))]
        public void TraitChatLinkObjectTest(string chatLink, TraitChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new TraitChatLink { TraitId = 1 };
            var chatLink2 = new TraitChatLink { TraitId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
