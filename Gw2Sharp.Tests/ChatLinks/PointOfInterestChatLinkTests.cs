using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class PointOfInterestChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> PointOfInterestChatLinks => new[]
        {
            new object[] { "[&BDgAAAA=]", new PointOfInterestChatLink { PointOfInterestId = 56 } },
            new object[] { "[&BEgAAAA=]", new PointOfInterestChatLink { PointOfInterestId = 72 } },
            new object[] { "[&BDkDAAA=]", new PointOfInterestChatLink { PointOfInterestId = 825 } }
        };

        [Theory]
        [MemberData(nameof(PointOfInterestChatLinks))]
        public void PointOfInterestChatLinkStringTest(string expected, PointOfInterestChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(PointOfInterestChatLinks))]
        public void PointOfInterestChatLinkObjectTest(string chatLink, PointOfInterestChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new PointOfInterestChatLink { PointOfInterestId = 1 };
            var chatLink2 = new PointOfInterestChatLink { PointOfInterestId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
