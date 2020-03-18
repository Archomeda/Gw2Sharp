using System.Collections.Generic;
using Gw2Sharp.Json.Converters;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class DictionaryIntKeyConverterTests
    {
        [Fact]
        public void CanConvertTest()
        {
            var converter = new DictionaryIntKeyConverter();
            Assert.True(converter.CanConvert(typeof(IDictionary<int, object>)));
            Assert.True(converter.CanConvert(typeof(IReadOnlyDictionary<int, object>)));
        }
    }
}
