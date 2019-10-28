using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class NpcTextChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> NpcTextChatLinks => new[]
        {
            new object[] { "[&AxcnAAA=]", new NpcTextChatLink { StringId = 10007 } },
            new object[] { "[&AxgnAAA=]", new NpcTextChatLink { StringId = 10008 } },
            new object[] { "[&AxknAAA=]", new NpcTextChatLink { StringId = 10009 } },
            new object[] { "[&AyAnAAA=]", new NpcTextChatLink { StringId = 10016 } }
        };

        [Theory]
        [MemberData(nameof(NpcTextChatLinks))]
        public void NpcTextChatLinkStringTest(string expected, NpcTextChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(NpcTextChatLinks))]
        public void NpcTextChatLinkObjectTest(string chatLink, NpcTextChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new NpcTextChatLink { StringId = 1 };
            var chatLink2 = new NpcTextChatLink { StringId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
