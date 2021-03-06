using System;
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

        [CastableType(TestCastableEnum.SomeValue, typeof(object))]
        private class TestCastableType : ICastableType<string, TestCastableEnum>
        {
            public ApiEnum<TestCastableEnum> Type => throw new NotImplementedException();
        }

        private class TestNotCastableType1 : ICastableType<string, TestCastableEnum>
        {
            public ApiEnum<TestCastableEnum> Type => throw new NotImplementedException();
        }

        private class TestNotCastableType2
        {
            public ApiEnum<TestCastableEnum> Type => throw new NotImplementedException();
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new CastableTypeConverter();
            Assert.True(converter.CanConvert(typeof(TestCastableType)));
        }

        [Fact]
        public void CanNotConvertTest()
        {
            var converter = new CastableTypeConverter();
            Assert.False(converter.CanConvert(typeof(TestNotCastableType1)));
            Assert.False(converter.CanConvert(typeof(TestNotCastableType2)));
        }
    }
}
