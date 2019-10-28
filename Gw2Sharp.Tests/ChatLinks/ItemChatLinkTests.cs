using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class ItemChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> ItemChatLinks => new[]
        {
            new object[] { "[&AgH1WQAA]", new ItemChatLink { ItemId = 23029, Quantity = 1 } },
            new object[] { "[&AgH2WQAA]", new ItemChatLink { ItemId = 23030, Quantity = 1 } },
            new object[] { "[&AgH3WQAA]", new ItemChatLink { ItemId = 23031, Quantity = 1 } },
            new object[] { "[&AgEAWgAA]", new ItemChatLink { ItemId = 23040, Quantity = 1 } },
            new object[] { "[&AgGqtgAA]", new ItemChatLink { ItemId = 46762, Quantity = 1 } },
            new object[] { "[&An2qtgAA]", new ItemChatLink { ItemId = 46762, Quantity = 125 } },
            new object[] { "[&AgGqtgBA/18AAA==]", new ItemChatLink { ItemId = 46762, Quantity = 1, Upgrade1Id = 24575 } },
            new object[] { "[&AgGqtgBg/18AACdgAAA=]", new ItemChatLink { ItemId = 46762, Quantity = 1, Upgrade1Id = 24575, Upgrade2Id = 24615 } },
            new object[] { "[&AgGqtgCAfQ4AAA==]", new ItemChatLink { ItemId = 46762, Quantity = 1, SkinId = 3709 } },
            new object[] { "[&AgGqtgDAfQ4AAP9fAAA=]", new ItemChatLink { ItemId = 46762, Quantity = 1, SkinId = 3709, Upgrade1Id = 24575 } },
            new object[] { "[&AgGqtgDgfQ4AAP9fAAAnYAAA]", new ItemChatLink { ItemId = 46762, Quantity = 1, SkinId = 3709, Upgrade1Id = 24575, Upgrade2Id = 24615 } }
        };

        [Theory]
        [MemberData(nameof(ItemChatLinks))]
        public void ItemChatLinkStringTest(string expected, ItemChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(ItemChatLinks))]
        public void ItemChatLinkObjectTest(string chatLink, ItemChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 2, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink3 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 7, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink4 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 99, Upgrade2Id = 99 };
            var chatLink5 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 10 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(chatLink3));
            Assert.False(chatLink.Equals(chatLink4));
            Assert.False(chatLink.Equals(chatLink5));
            Assert.False(chatLink2.Equals(chatLink3));
            Assert.False(chatLink2.Equals(chatLink4));
            Assert.False(chatLink2.Equals(chatLink5));
            Assert.False(chatLink3.Equals(chatLink4));
            Assert.False(chatLink3.Equals(chatLink5));
            Assert.False(chatLink4.Equals(chatLink5));
            Assert.False(chatLink.Equals(null));
            Assert.False(chatLink2.Equals(null));
            Assert.False(chatLink3.Equals(null));
            Assert.False(chatLink4.Equals(null));
            Assert.False(chatLink5.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 2, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink3 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 7, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink4 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 99, Upgrade2Id = 99 };
            var chatLink5 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 10 };
            Assert.True(chatLink != chatLink2);
            Assert.True(chatLink != chatLink3);
            Assert.True(chatLink != chatLink4);
            Assert.True(chatLink != chatLink5);
            Assert.True(chatLink2 != chatLink3);
            Assert.True(chatLink2 != chatLink4);
            Assert.True(chatLink2 != chatLink5);
            Assert.True(chatLink3 != chatLink4);
            Assert.True(chatLink3 != chatLink5);
            Assert.True(chatLink4 != chatLink5);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink2 = new ItemChatLink { ItemId = 12, Quantity = 2, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink3 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 7, Upgrade1Id = 76, Upgrade2Id = 99 };
            var chatLink4 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 99, Upgrade2Id = 99 };
            var chatLink5 = new ItemChatLink { ItemId = 12, Quantity = 1, SkinId = 5, Upgrade1Id = 76, Upgrade2Id = 10 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink3.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink4.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink5.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink3.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink4.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink5.GetHashCode());
            Assert.NotEqual(chatLink3.GetHashCode(), chatLink4.GetHashCode());
            Assert.NotEqual(chatLink3.GetHashCode(), chatLink5.GetHashCode());
            Assert.NotEqual(chatLink4.GetHashCode(), chatLink5.GetHashCode());
        }
    }
}
