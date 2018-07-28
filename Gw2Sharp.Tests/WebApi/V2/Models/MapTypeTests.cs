using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class MapTypeTests
    {
        private class JsonObject
        {
            public ApiEnum<MapType> MapType { get; set; }
        }

        [Fact]
        public void DefaultValueTest()
        {
            const string json = "{\"MapType\":\"SomeRandomTypeThatDoesntExist\"}";
            var obj = JsonConvert.DeserializeObject<JsonObject>(json);
            Assert.Equal("SomeRandomTypeThatDoesntExist", obj.MapType.RawValue);
            Assert.Equal(MapType.Unknown, obj.MapType.Value);
        }
    }
}
