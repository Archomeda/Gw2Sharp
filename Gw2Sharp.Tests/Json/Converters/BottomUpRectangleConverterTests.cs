using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class BottomUpRectangleConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new BottomUpRectangleConverter();
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new BottomUpRectangleConverter();
            Assert.True(converter.CanConvert(typeof(Rectangle)));
        }
    }
}
