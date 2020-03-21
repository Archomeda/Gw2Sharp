using System.Text.Json;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class MapTypeTests
    {
        private class JsonObject
        {
            public ApiEnum<MapType> MapType { get; set; } = default!;
        }

        [Fact]
        public void DefaultValueTest()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ApiEnumConverter());

            const string json = "{\"MapType\":\"SomeRandomTypeThatDoesntExist\"}";
            var obj = JsonSerializer.Deserialize<JsonObject>(json, options);
            Assert.Equal("SomeRandomTypeThatDoesntExist", obj.MapType.RawValue);
            Assert.Equal(MapType.Unknown, obj.MapType.Value);
        }
    }
}
