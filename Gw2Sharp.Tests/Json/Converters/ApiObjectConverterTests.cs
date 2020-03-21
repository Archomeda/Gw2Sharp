using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiObjectConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new ApiObjectConverter();
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiObjectConverter();
            Assert.True(converter.CanConvert(typeof(IApiV2Object)));
        }
    }
}
