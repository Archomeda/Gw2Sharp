using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class TopDownRectangleConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new TopDownRectangleConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Rectangle(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new TopDownRectangleConverter();
            Assert.True(converter.CanConvert(typeof(Rectangle)));
        }
    }
}
