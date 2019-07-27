using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class Coordinates2ConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new Coordinates2Converter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Coordinates2(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new Coordinates2Converter();
            Assert.True(converter.CanConvert(typeof(Coordinates2)));
        }
    }
}
