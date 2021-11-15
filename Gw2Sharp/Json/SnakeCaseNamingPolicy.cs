using System.Linq;
using System.Text.Json;

namespace Gw2Sharp.Json
{
    internal class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy SnakeCase { get; } = new();

        public override string ConvertName(string name) =>
            string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? $"_{x}" : x.ToString())).ToLowerInvariant();
    }
}
