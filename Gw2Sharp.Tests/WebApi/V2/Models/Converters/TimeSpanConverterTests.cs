using System;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
{
    public class TimeSpanConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new TimeSpanConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new TimeSpan(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new TimeSpanConverter();
            Assert.True(converter.CanConvert(typeof(TimeSpan)));
        }
    }
}
