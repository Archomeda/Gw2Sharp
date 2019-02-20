using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
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
