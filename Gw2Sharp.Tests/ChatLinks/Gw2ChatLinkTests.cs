using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> CoinChatLinks => new[]
        {
            new object[] { "[&AQAAAAA=]", new CoinChatLink { Coins = 0 } },
            new object[] { "[&AQEAAAA=]", new CoinChatLink { Coins = 1 } },
            new object[] { "[&AdsnAAA=]", new CoinChatLink { Coins = 10203 } }
        };

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

        public static IEnumerable<object[]> NpcTextChatLinks => new[]
        {
            new object[] { "[&AxcnAAA=]", new NpcTextChatLink { StringId = 10007 } },
            new object[] { "[&AxgnAAA=]", new NpcTextChatLink { StringId = 10008 } },
            new object[] { "[&AxknAAA=]", new NpcTextChatLink { StringId = 10009 } },
            new object[] { "[&AyAnAAA=]", new NpcTextChatLink { StringId = 10016 } }
        };

        public static IEnumerable<object[]> PointOfInterestChatLinks => new[]
        {
            new object[] { "[&BDgAAAA=]", new PointOfInterestChatLink { PointOfInterestId = 56 } },
            new object[] { "[&BEgAAAA=]", new PointOfInterestChatLink { PointOfInterestId = 72 } },
            new object[] { "[&BDkDAAA=]", new PointOfInterestChatLink { PointOfInterestId = 825 } }
        };

        public static IEnumerable<object[]> SkillChatLinks => new[]
        {
            new object[] { "[&BucCAAA=]", new SkillChatLink { SkillId = 743 } },
            new object[] { "[&BnMVAAA=]", new SkillChatLink { SkillId = 5491 } },
            new object[] { "[&Bn0VAAA=]", new SkillChatLink { SkillId = 5501 } }
        };

        public static IEnumerable<object[]> TraitChatLinks => new[]
        {
            new object[] { "[&B/IDAAA=]", new TraitChatLink { TraitId = 1010 } },
            new object[] { "[&B3QHAAA=]", new TraitChatLink { TraitId = 1908 } },
            new object[] { "[&B9YHAAA=]", new TraitChatLink { TraitId = 2006 } }
        };

        public static IEnumerable<object[]> RecipeChatLinks => new[]
        {
            new object[] { "[&CQEAAAA=]", new RecipeChatLink { RecipeId = 1 } },
            new object[] { "[&CQIAAAA=]", new RecipeChatLink { RecipeId = 2 } },
            new object[] { "[&CQcAAAA=]", new RecipeChatLink { RecipeId = 7 } }
        };

        public static IEnumerable<object[]> SkinChatLinks => new[]
        {
            new object[] { "[&CgQAAAA=]", new SkinChatLink { SkinId = 4 } },
            new object[] { "[&CrkOAAA=]", new SkinChatLink { SkinId = 3769 } },
            new object[] { "[&Ck4cAAA=]", new SkinChatLink { SkinId = 7246 } }
        };

        public static IEnumerable<object[]> OutfitChatLinks => new[]
        {
            new object[] { "[&CwQAAAA=]", new OutfitChatLink { OutfitId = 4 } },
            new object[] { "[&CykAAAA=]", new OutfitChatLink { OutfitId = 41 } },
            new object[] { "[&C1AAAAA=]", new OutfitChatLink { OutfitId = 80 } }
        };

        [Theory]
        [MemberData(nameof(CoinChatLinks))]
        public void CoinChatLinkStringTest(string expected, CoinChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(CoinChatLinks))]
        public void CoinChatLinkObjectTest(string chatLink, CoinChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(ItemChatLinks))]
        public void ItemChatLinkStringTest(string expected, ItemChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(ItemChatLinks))]
        public void ItemChatLinkObjectTest(string chatLink, ItemChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(NpcTextChatLinks))]
        public void NpcTextChatLinkStringTest(string expected, NpcTextChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(NpcTextChatLinks))]
        public void NpcTextChatLinkObjectTest(string chatLink, NpcTextChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(PointOfInterestChatLinks))]
        public void PointOfInterestChatLinkStringTest(string expected, PointOfInterestChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(PointOfInterestChatLinks))]
        public void PointOfInterestChatLinkObjectTest(string chatLink, PointOfInterestChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(SkillChatLinks))]
        public void SkillChatLinkStringTest(string expected, SkillChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(SkillChatLinks))]
        public void SkillChatLinkObjectTest(string chatLink, SkillChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(TraitChatLinks))]
        public void TraitChatLinkStringTest(string expected, TraitChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(TraitChatLinks))]
        public void TraitChatLinkObjectTest(string chatLink, TraitChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(RecipeChatLinks))]
        public void RecipeChatLinkStringTest(string expected, RecipeChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(RecipeChatLinks))]
        public void RecipeChatLinkObjectTest(string chatLink, RecipeChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(SkinChatLinks))]
        public void SkinChatLinkStringTest(string expected, SkinChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(SkinChatLinks))]
        public void SkinChatLinkObjectTest(string chatLink, SkinChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Theory]
        [MemberData(nameof(OutfitChatLinks))]
        public void OutfitChatLinkStringTest(string expected, OutfitChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(OutfitChatLinks))]
        public void OutfitChatLinkObjectTest(string chatLink, OutfitChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        private void AssertChatLinkString(string expected, IGw2ChatLink chatLinkObject)
        {
            Assert.Equal(expected, chatLinkObject.ToString());
        }

        private void AssertChatLinkObject(string chatLink, IGw2ChatLink expected)
        {
            var actual = Gw2ChatLink.Parse(chatLink);
            Assert.Equal(expected, actual);

            bool isValid = Gw2ChatLink.TryParse(chatLink, out actual);
            Assert.True(isValid);
            Assert.Equal(expected, actual);
        }
    }
}
