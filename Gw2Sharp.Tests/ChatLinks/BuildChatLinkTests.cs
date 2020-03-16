using System.Collections.Generic;
using Gw2Sharp.ChatLinks;
using Gw2Sharp.Models;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class BuildChatLinkTests : Gw2ChatLinkTests
    {
        public static IEnumerable<object[]> BuildChatLinks => new[]
        {
            new object[] { "[&DQIzNSQtEipwAHAA1xJxANwSqgDEEqwAwhKcAAAAAAAAAAAAAAAAAAAAAAA=]", new BuildChatLink
            {
                Profession = ProfessionType.Warrior,
                Specialization1Id = 51,
                Specialization1Trait1Index = 1,
                Specialization1Trait2Index = 1,
                Specialization1Trait3Index = 3,
                Specialization2Id = 36,
                Specialization2Trait1Index = 1,
                Specialization2Trait2Index = 3,
                Specialization2Trait3Index = 2,
                Specialization3Id = 18,
                Specialization3Trait1Index = 2,
                Specialization3Trait2Index = 2,
                Specialization3Trait3Index = 2,
                TerrestrialHealingSkillPaletteId = 112,
                AquaticHealingSkillPaletteId = 112,
                TerrestrialUtility1SkillPaletteId = 4823,
                AquaticUtility1SkillPaletteId = 113,
                TerrestrialUtility2SkillPaletteId = 4828,
                AquaticUtility2SkillPaletteId = 170,
                TerrestrialUtility3SkillPaletteId = 4804,
                AquaticUtility3SkillPaletteId = 172,
                TerrestrialEliteSkillPaletteId = 4802,
                AquaticEliteSkillPaletteId = 156
            } }
        };

        [Theory]
        [MemberData(nameof(BuildChatLinks))]
        public void BuildChatLinkStringTest(string expected, BuildChatLink chatLinkObject) =>
            this.AssertChatLinkString(expected, chatLinkObject);

        [Theory]
        [MemberData(nameof(BuildChatLinks))]
        public void BuildChatLinkObjectTest(string chatLink, BuildChatLink expected) =>
            this.AssertChatLinkObject(chatLink, expected);

        [Fact]
        public void EqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            Assert.True(chatLink.Equals((object)chatLink2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Guardian, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink3 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 222, Specialization2Id = 100, Specialization3Id = 14 };
            var chatLink4 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 147 };
            Assert.False(chatLink.Equals(chatLink2));
            Assert.False(chatLink.Equals(chatLink3));
            Assert.False(chatLink.Equals(chatLink4));
            Assert.False(chatLink2.Equals(chatLink3));
            Assert.False(chatLink2.Equals(chatLink4));
            Assert.False(chatLink3.Equals(chatLink4));
            Assert.False(chatLink.Equals(null));
            Assert.False(chatLink2.Equals(null));
            Assert.False(chatLink3.Equals(null));
            Assert.False(chatLink4.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            Assert.True(chatLink == chatLink2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Guardian, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink3 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 222, Specialization2Id = 100, Specialization3Id = 14 };
            var chatLink4 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 147 };
            Assert.True(chatLink != chatLink2);
            Assert.True(chatLink != chatLink3);
            Assert.True(chatLink != chatLink4);
            Assert.True(chatLink2 != chatLink3);
            Assert.True(chatLink2 != chatLink4);
            Assert.True(chatLink3 != chatLink4);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            Assert.Equal(chatLink.GetHashCode(), chatLink2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var chatLink = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink2 = new BuildChatLink { Profession = ProfessionType.Guardian, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 14 };
            var chatLink3 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 222, Specialization2Id = 100, Specialization3Id = 14 };
            var chatLink4 = new BuildChatLink { Profession = ProfessionType.Warrior, Specialization1Id = 123, Specialization2Id = 234, Specialization3Id = 147 };
            Assert.NotEqual(chatLink.GetHashCode(), chatLink2.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink3.GetHashCode());
            Assert.NotEqual(chatLink.GetHashCode(), chatLink4.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink3.GetHashCode());
            Assert.NotEqual(chatLink2.GetHashCode(), chatLink4.GetHashCode());
            Assert.NotEqual(chatLink3.GetHashCode(), chatLink4.GetHashCode());
        }
    }
}
