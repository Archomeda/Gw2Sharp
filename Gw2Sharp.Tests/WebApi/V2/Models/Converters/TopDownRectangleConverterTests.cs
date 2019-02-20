using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
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
