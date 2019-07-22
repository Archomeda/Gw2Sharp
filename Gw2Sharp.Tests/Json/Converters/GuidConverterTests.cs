using System;
using Gw2Sharp.Json.Converters;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class GuidConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new GuidConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Guid(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new GuidConverter();
            Assert.True(converter.CanConvert(typeof(Guid)));
        }
    }
}
