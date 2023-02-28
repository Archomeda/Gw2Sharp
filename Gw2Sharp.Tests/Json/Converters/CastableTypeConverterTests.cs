using System;
using System.Text.Json;
using FluentAssertions;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class CastableTypeConverterTests
    {
        private enum TestCastableEnum
        {
            SomeValue
        }

        [CastableType(TestCastableEnum.SomeValue, typeof(CastableTypeSomeValue))]
        private class BaseCastableType : ICastableType<string, TestCastableEnum>
        {
            public ApiEnum<TestCastableEnum> Type { get; set; }
        }

        private class CastableTypeSomeValue : BaseCastableType { }

        private class NonCastableType1 : ICastableType<string, TestCastableEnum>
        {
            public ApiEnum<TestCastableEnum> Type { get; set; }
        }

        private class NonCastableType2
        {
            public ApiEnum<TestCastableEnum> Type { get; set; }
        }


        [Fact]
        public void CanConvertTest()
        {
            var converter = new CastableTypeConverter();
            Assert.True(converter.CanConvert(typeof(BaseCastableType)));
        }

        [Fact]
        public void CanNotConvertTest()
        {
            var converter = new CastableTypeConverter();
            Assert.False(converter.CanConvert(typeof(NonCastableType1)));
            Assert.False(converter.CanConvert(typeof(NonCastableType2)));
        }

        [Theory]
        [InlineData("""{"type": "NonExistent"}""", typeof(BaseCastableType))] // Fall back to base type
        [InlineData("""{"type": "SomeValue"}""", typeof(CastableTypeSomeValue))]
        public void DeserializesToCastableTypeTest(string json, Type type)
        {
            var options = new JsonSerializerOptions { Converters = { new CastableTypeConverter() } };
            var result = JsonSerializer.Deserialize<BaseCastableType>(json, options);
            result.Should().BeOfType(type);
        }
    }
}
