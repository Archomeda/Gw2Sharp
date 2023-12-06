using Gw2Sharp.Json;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class SnakeCaseNamingPolicyTests
    {
        [Fact]
        public void ConvertsUpperCamelCase()
        {
            const string propertyName = "UpperCamelCasePropertyName";
            string convertedPropertyName = SnakeCaseNamingPolicy.SnakeCase.ConvertName(propertyName);
            Assert.Equal("upper_camel_case_property_name", convertedPropertyName);
        }

        [Fact]
        public void ConvertsLowerCamelCase()
        {
            const string propertyName = "lowerCamelCasePropertyName";
            string convertedPropertyName = SnakeCaseNamingPolicy.SnakeCase.ConvertName(propertyName);
            Assert.Equal("lower_camel_case_property_name", convertedPropertyName);
        }

        [Fact]
        public void PreservesSnakeCase()
        {
            const string propertyName = "snake_case_property_name";
            string convertedPropertyName = SnakeCaseNamingPolicy.SnakeCase.ConvertName(propertyName);
            Assert.Equal(propertyName, convertedPropertyName);
        }

        [Theory]
        [InlineData("GuildWars2EOD", "guild_wars2_eod")]
        [InlineData("GW2EndOfDragons", "gw2_end_of_dragons")]
        [InlineData("LWSeason2", "lwseason2")]
        [InlineData("LW_Season2", "lw_season2")]
        public void HandlesAcronyms(string propertyName, string expectedConvertedPropertyName)
        {
            string convertedPropertyName = SnakeCaseNamingPolicy.SnakeCase.ConvertName(propertyName);
            Assert.Equal(expectedConvertedPropertyName, convertedPropertyName);
        }
    }
}
