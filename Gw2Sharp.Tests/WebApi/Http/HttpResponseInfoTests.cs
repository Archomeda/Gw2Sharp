using System;
using System.Collections.Generic;
using System.Net;
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
                { "Cache-Control", "\"public, max-age=60\"" }
            };

            var response = new HttpResponseInfo(HttpStatusCode.OK, responseHeaders);
            Assert.Equal(responseHeaders, responseHeaders);
            Assert.Equal(TimeSpan.FromSeconds(60), response.CacheMaxAge);
        }
    }
}
