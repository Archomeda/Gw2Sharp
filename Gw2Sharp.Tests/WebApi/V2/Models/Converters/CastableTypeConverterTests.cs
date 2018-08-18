using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
{
    public class CastableTypeConverterTests
    {
        private enum TestCastableEnum
        {
            SomeValue
        }

        [CastableType(TestCastableEnum.SomeValue, null)]
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
        public void NoWriteTest()
        {
            var converter = new CastableTypeConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(null, null, null));
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
