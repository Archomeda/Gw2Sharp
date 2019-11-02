using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class RecipeChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> RecipeChatLinks => new[]
        {
            new object[] { "[&CQEAAAA=]", new RecipeChatLink { RecipeId = 1 } },
            new object[] { "[&CQIAAAA=]", new RecipeChatLink { RecipeId = 2 } },
            new object[] { "[&CQcAAAA=]", new RecipeChatLink { RecipeId = 7 } }
        };

        [Theory]
        [MemberData(nameof(RecipeChatLinks))]
        public void RecipeChatLinkStringTest(string expected, RecipeChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(RecipeChatLinks))]
        public void RecipeChatLinkObjectTest(string chatLink, RecipeChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 1 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 2 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 1 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 2 };
            Assert.True(chatLink != chatLink2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 1 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new RecipeChatLink { RecipeId = 1 };
            var chatLink2 = new RecipeChatLink { RecipeId = 2 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }
    }
}
