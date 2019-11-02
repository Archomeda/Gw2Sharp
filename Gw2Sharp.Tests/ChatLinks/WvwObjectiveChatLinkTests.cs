using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class WvwObjectiveChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> WvwObjectiveChatLinks => new[]
        {
            new object[] { "[&DAMAAAAmAAAA]", new WvwObjectiveChatLink { ObjectiveId = 3, MapId = 38 } },
            new object[] { "[&DA0AAAAmAAAA]", new WvwObjectiveChatLink { ObjectiveId = 13, MapId = 38 } },
            new object[] { "[&DBMAAAAmAAAA]", new WvwObjectiveChatLink { ObjectiveId = 19, MapId = 38 } },
            new object[] { "[&DEEAAABfAAAA]", new WvwObjectiveChatLink { ObjectiveId = 65, MapId = 95 } }
        };

        [Theory]
        [MemberData(nameof(WvwObjectiveChatLinks))]
        public void WvwObjectiveChatLinkStringTest(string expected, WvwObjectiveChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(WvwObjectiveChatLinks))]
        public void WvwObjectiveChatLinkObjectTest(string chatLink, WvwObjectiveChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 3 };
            var chatLink3 = new WvwObjectiveChatLink { ObjectiveId = 2, MapId = 3 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(chatLink3));
            Assert.False(chatLink2.Equals(chatLink3));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 3 };
            var chatLink3 = new WvwObjectiveChatLink { ObjectiveId = 2, MapId = 3 };
            Assert.True(chatLink != chatLink2);
            Assert.True(chatLink != chatLink3);
            Assert.True(chatLink2 != chatLink3);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 2 };
            var chatLink2 = new WvwObjectiveChatLink { ObjectiveId = 1, MapId = 3 };
            var chatLink3 = new WvwObjectiveChatLink { ObjectiveId = 2, MapId = 3 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink3.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink3.GetHashCode());
        }
    }
}
