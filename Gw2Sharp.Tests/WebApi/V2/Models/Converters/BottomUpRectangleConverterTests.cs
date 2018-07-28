using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
{
    public class BottomUpRectangleConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new BottomUpRectangleConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(null, new Rectangle(), null));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new BottomUpRectangleConverter();
            Assert.True(converter.CanConvert(typeof(Rectangle)));
        }
    }
}
