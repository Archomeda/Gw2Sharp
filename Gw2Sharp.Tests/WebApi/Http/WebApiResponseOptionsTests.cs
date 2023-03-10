using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Gw2Sharp.WebApi.Http;
using Objectivity.AutoFixture.XUnit2.AutoNSubstitute.Attributes;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class WebApiResponseOptionsTests
    {
        [Theory]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "", "", null)]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "", "")]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "quests", "", null)]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "quests", "")]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "quests", "/23", null)]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "quests", "/23")]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "account/character", "", null)]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "account/character", "")]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "account/character", "/Test Character", null)]
        [InlineAutoMockData("https://api.guildwars2.com/v2/", "account/character", "/Test Character")]
        public void CreatesCorrectUrl(string baseUrl, string endpointPath, string pathSuffix, IDictionary<string, string>? endpointQuery)
        {
            endpointQuery ??= new Dictionary<string, string>();

            string expected = $"{baseUrl}{endpointPath}{pathSuffix}" +
                (endpointQuery.Count > 0 ? "?" + string.Join("&", endpointQuery.Select(x => $"{Uri.EscapeDataString(x.Key)}{(x.Value != null ? $"={Uri.EscapeDataString(x.Value)}" : string.Empty)}")) : string.Empty);
            string actual = new WebApiRequestOptions
            {
                BaseUrl = baseUrl,
                EndpointPath = endpointPath,
                PathSuffix = pathSuffix,
                EndpointQuery = endpointQuery
            }.Url.AbsoluteUri;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
