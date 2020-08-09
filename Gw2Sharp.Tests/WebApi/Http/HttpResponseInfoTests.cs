using System;
using System.Collections.Generic;
using System.Net;
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

            var response = new HttpResponseInfo(HttpStatusCode.OK, responseHeaders);
            response.RawResponseHeaders.Should().BeEquivalentTo(responseHeaders);
            response.CacheMaxAge.Should().Be(60.Seconds());
        }

        [Fact]
        public void ReadsCustomGw2SharpHeadersTest()
        {
            var responseHeaders = new Dictionary<string, string>
            {
                ["X-Gw2Sharp-Cache-State"] = CacheState.PartiallyFromCache.ToString()
            };

            var response = new HttpResponseInfo(HttpStatusCode.OK, responseHeaders);
            response.CacheState.Should().Be(CacheState.PartiallyFromCache);
        }
    }
}
