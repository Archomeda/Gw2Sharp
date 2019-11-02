using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class SkillChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> SkillChatLinks => new[]
        {
            new object[] { "[&BucCAAA=]", new SkillChatLink { SkillId = 743 } },
            new object[] { "[&BnMVAAA=]", new SkillChatLink { SkillId = 5491 } },
            new object[] { "[&Bn0VAAA=]", new SkillChatLink { SkillId = 5501 } }
        };

        [Theory]
        [MemberData(nameof(SkillChatLinks))]
        public void SkillChatLinkStringTest(string expected, SkillChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(SkillChatLinks))]
        public void SkillChatLinkObjectTest(string chatLink, SkillChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new SkillChatLink { SkillId = 1 };
            var chatLink2 = new SkillChatLink { SkillId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
