using System;
using System.Text.Json;
using FluentAssertions;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiEnumConverterTests
    {
        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiEnumConverter();
            Assert.True(converter.CanConvert(typeof(ApiEnum<>)));
        }

        [Theory]
        [InlineData("\"Value2\"", TestEnum.Value2, "Value2")]
        [InlineData("2", TestEnum.Value2, "2")]
        public void DeserializeWithoutUnknownsCorrectly(string json, TestEnum expectedValue, string expectedRaw)
        {
            var actual = JsonSerializer.Deserialize<ApiEnum<TestEnum>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiEnumConverter() }
            });

            actual.IsUnknown.Should().BeFalse();
            actual.Value.Should().Be(expectedValue);
            actual.RawValue.Should().Be(expectedRaw);
        }

        [Theory]
        [InlineData("\"Unknown\"", default(TestEnum), "Unknown")]
        [InlineData("\"\"", default(TestEnum), "")]
        public void DeserializeWithUnknownsCorrectly(string json, TestEnum expectedValue, string expectedRaw)
        {
            var actual = JsonSerializer.Deserialize<ApiEnum<TestEnum>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiEnumConverter() }
            });

            actual.IsUnknown.Should().BeTrue();
            actual.Value.Should().Be(expectedValue);
            actual.RawValue.Should().Be(expectedRaw);
        }

        [Theory]
        [InlineData("{}")]
        [InlineData("[]")]
        [InlineData("undefined")]
        public void DeserializeFromUnsupportedThrowsException(string json)
        {
            Action action = () => JsonSerializer.Deserialize<ApiEnum<TestEnum>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiEnumConverter() }
            });
            action.Should().Throw<JsonException>();
        }

        public enum TestEnum
        {
            Value0,
            Value1,
            Value2
        }
    }
}
