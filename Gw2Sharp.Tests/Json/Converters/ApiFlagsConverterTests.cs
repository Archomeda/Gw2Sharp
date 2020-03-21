using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiFlagsConverterTests
    {
        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiFlagsConverter();
            Assert.True(converter.CanConvert(typeof(ApiFlags<>)));
        }
    }
}
