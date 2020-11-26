using System.Collections.Generic;
using System.Net;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.WebApi.Http;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class HttpResponseInfoTests
    {
        [Fact]
        public void ConstructorIgnoresInvalidQuotesInCacheControlHeaderTest()
        {
            var responseHeaders = new Dictionary<string, string>
            {
                ["Cache-Control"] = "\"public, max-age=60\""
            };

            var response = new HttpResponseInfo(HttpStatusCode.OK, CacheState.FromLive, responseHeaders);
            response.RawResponseHeaders.Should().BeEquivalentTo(responseHeaders);
            response.CacheMaxAge.Should().Be(60.Seconds());
        }

        [Theory]
        [AutoData]
        public void PassesCacheState(CacheState cacheState)
        {
            var response = new HttpResponseInfo(HttpStatusCode.OK, cacheState, null);
            response.CacheState.Should().Be(cacheState);
        }
    }
}
