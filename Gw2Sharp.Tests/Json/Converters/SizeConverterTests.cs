using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class SizeConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new SizeConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Size(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new SizeConverter();
            Assert.True(converter.CanConvert(typeof(Size)));
        }
    }
}
