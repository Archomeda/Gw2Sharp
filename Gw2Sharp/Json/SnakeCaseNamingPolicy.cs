using System;
using System.Text;
using System.Text.Json;

namespace Gw2Sharp.Json
{
    /// <remarks>
    /// Many use cases are not supported (e.g. emojis).
    /// Use with caution.
    /// </remarks>
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        /// <inheritdoc/>
        public static SnakeCaseNamingPolicy SnakeCase => new();

        /// <inheritdoc/>
        public override string ConvertName(string name)
        {
            var sb = new StringBuilder();
            var nameSpan = name.AsSpan();
            bool lastCharWasLower = false;

            for (int i = 0; i < nameSpan.Length; ++i)
            {
                char character = nameSpan[i];

                if (char.IsUpper(character))
                {
                    if (lastCharWasLower)
                    {
                        sb.Append('_');
                    }
                    sb.Append(char.ToLowerInvariant(character));
                    lastCharWasLower = false;
                }
                else if (character == '_')
                {
                    sb.Append('_');
                    lastCharWasLower = false;
                }
                else {
                    sb.Append(character);
                    lastCharWasLower = true;
                }
            }

            return sb.ToString();
        }
    }
}
