using System;
using System.Collections.Generic;
using Gw2Sharp.Json.Converters;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class CompactMapConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new CompactMapConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, new Dictionary<int, int>(), default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new CompactMapConverter();
            Assert.True(converter.CanConvert(typeof(IDictionary<int, int>)));
        }
    }
}
