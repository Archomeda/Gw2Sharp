using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
{
    public class CastableTypeConverterTests
    {
        private class TestCastableType : ICastableType<string, Enum>
        {
            public ApiEnum<Enum> Type => throw new NotImplementedException();
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
    }
}
