using System;
using Gw2Sharp.Json.Converters;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class TimeSpanConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new TimeSpanConverter();
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new TimeSpanConverter();
            Assert.True(converter.CanConvert(typeof(TimeSpan)));
        }
    }
}
