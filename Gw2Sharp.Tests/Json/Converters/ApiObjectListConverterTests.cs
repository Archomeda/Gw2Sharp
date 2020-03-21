using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiObjectListConverterTests
    {
        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiObjectListConverter();
            Assert.True(converter.CanConvert(typeof(IApiV2ObjectList<>)));
        }
    }
}
