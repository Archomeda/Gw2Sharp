using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class ApiEnumConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new ApiEnumConverter();
            Assert.False(converter.CanWrite);
            Assert.Throws<NotImplementedException>(() => converter.WriteJson(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new ApiEnumConverter();
            Assert.True(converter.CanConvert(typeof(ApiEnum<>)));
        }
    }
}
