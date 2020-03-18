using System;
using Gw2Sharp.Json.Converters;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class StringAsIntConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new StringAsIntConverter();
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new StringAsIntConverter();
            Assert.True(converter.CanConvert(typeof(int?)));
        }
    }
}
