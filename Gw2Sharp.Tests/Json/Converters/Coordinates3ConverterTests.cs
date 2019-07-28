using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class Coordinates3ConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new Coordinates3Converter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Coordinates3(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new Coordinates3Converter();
            Assert.True(converter.CanConvert(typeof(Coordinates3)));
        }
    }
}
