using System;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models.Converters
{
    public class SizeConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new SizeConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(null, new Size(), null));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new SizeConverter();
            Assert.True(converter.CanConvert(typeof(Size)));
        }
    }
}
