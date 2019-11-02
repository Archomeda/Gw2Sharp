using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class SkinChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> SkinChatLinks => new[]
        {
            new object[] { "[&CgQAAAA=]", new SkinChatLink { SkinId = 4 } },
            new object[] { "[&CrkOAAA=]", new SkinChatLink { SkinId = 3769 } },
            new object[] { "[&Ck4cAAA=]", new SkinChatLink { SkinId = 7246 } }
        };

        [Theory]
        [MemberData(nameof(SkinChatLinks))]
        public void SkinChatLinkStringTest(string expected, SkinChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(SkinChatLinks))]
        public void SkinChatLinkObjectTest(string chatLink, SkinChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new SkinChatLink { SkinId = 1 };
            var chatLink2 = new SkinChatLink { SkinId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
