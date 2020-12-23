using System;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiFlagsConverterTests
    {
        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiFlagsConverter();
            Assert.True(converter.CanConvert(typeof(ApiFlags<>)));
        }

        public static readonly object[] DeserializeCorrectlyWithoutUnknownsCases =
        {
            new object[]
            {
                "[\"Flag1\"]",
                TestFlags.Flag1,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag1, "Flag1")
                }
            },
            new object[]
            {
                "[\"Flag1\",\"Flag2\"]",
                TestFlags.Flag1 | TestFlags.Flag2,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag1, "Flag1"),
                    new ApiEnum<TestFlags>(TestFlags.Flag2, "Flag2")
                }
            },
            new object[]
            {
                "[1,2]",
                TestFlags.Flag1 | TestFlags.Flag2,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag1, "1"),
                    new ApiEnum<TestFlags>(TestFlags.Flag2, "2")
                }
            },
            new object[]
            {
                "[\"Flag1\",2]",
                TestFlags.Flag1 | TestFlags.Flag2,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag1, "Flag1"),
                    new ApiEnum<TestFlags>(TestFlags.Flag2, "2")
                }
            }
        };

        [Theory]
        [MemberData(nameof(DeserializeCorrectlyWithoutUnknownsCases))]
        public void DeserializeCorrectlyWithoutUnknowns(string json, TestFlags expectedValue, ApiEnum<TestFlags>[] expectedEnums)
        {
            var actual = JsonSerializer.Deserialize<ApiFlags<TestFlags>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiFlagsConverter() }
            });

            actual.HasUnknowns.Should().BeFalse();
            actual.UnknownList.Should().BeEmpty();
            actual.List.Should().BeEquivalentTo(expectedEnums);
        }

        public static readonly object[] DeserializeCorrectlyWithUnknownsCases =
        {
            new object[]
            {
                "[\"Flag1\",\"Unknown\"]",
                TestFlags.Flag1,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag1, "Flag1")
                },
                new[]
                {
                    new ApiEnum<TestFlags>(default , "Unknown")
                }
            },
            new object[]
            {
                "[\"\",\"Flag2\"]",
                TestFlags.Flag1 | TestFlags.Flag2,
                new[]
                {
                    new ApiEnum<TestFlags>(TestFlags.Flag2, "Flag2")
                },
                new[]
                {
                    new ApiEnum<TestFlags>(default, "")
                }
            }
        };

        [Theory]
        [MemberData(nameof(DeserializeCorrectlyWithUnknownsCases))]
        public void DeserializeCorrectlyWithUnknowns(string json, TestFlags expectedValue, ApiEnum<TestFlags>[] expectedEnums, ApiEnum<TestFlags>[] expectedUnknowns)
        {
            var actual = JsonSerializer.Deserialize<ApiFlags<TestFlags>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiFlagsConverter() }
            });

            actual.HasUnknowns.Should().BeTrue();
            actual.UnknownList.Should().BeEquivalentTo(expectedUnknowns);
            actual.List.Should().BeEquivalentTo(expectedEnums.Concat(expectedUnknowns));
        }

        [Theory]
        [InlineData("2")]
        [InlineData("undefined")]
        [InlineData("{}")]
        public void DeserializeFromUnsupportedThrowsException(string json)
        {
            Action action = () => JsonSerializer.Deserialize<ApiFlags<TestFlags>>(json, new JsonSerializerOptions
            {
                Converters = { new ApiEnumConverter() }
            });
            action.Should().Throw<JsonException>();
        }

        [Flags]
        public enum TestFlags
        {
            Flag1 = 1,
            Flag2 = 2,
            Flag3 = 4
        }
    }
}
