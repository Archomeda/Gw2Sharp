
using System.Text.Json;
using Gw2Sharp.Json;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.Benchmarks
{
    public class SerializationHelpers
    {
        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.SnakeCase
            };
            options.Converters.Add(new ApiEnumConverter());
            options.Converters.Add(new ApiFlagsConverter());
            options.Converters.Add(new ApiObjectConverter());
            options.Converters.Add(new ApiObjectListConverter());
            options.Converters.Add(new CastableTypeConverter());
            options.Converters.Add(new DictionaryIntKeyConverter());
            options.Converters.Add(new RenderUrlConverter(new Connection(), null!));
            options.Converters.Add(new TimeSpanConverter());
            return options;
        }
    }
}
