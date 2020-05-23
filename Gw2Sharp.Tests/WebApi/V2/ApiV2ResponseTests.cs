using System;
using System.Collections.Generic;
using System.Net;
using Gw2Sharp.Tests.WebApi.Http;
using Gw2Sharp.WebApi.V2;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2
{
    public class ApiV2ResponseTests : HttpResponseInfoTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var statusCode = HttpStatusCode.OK;
            var requestHeaders = new Dictionary<string, string>
            {
                { "X-Test", "Test" }
            };
            var responseHeaders = new Dictionary<string, string>
            {
                { "Cache-Control", "public,max-age=60" },
                { "Date", "2019-05-23T22:00:00Z" },
                { "Expires", "2019-05-24T00:00:00Z" },
                { "Last-Modified", "2019-05-23T20:00:00Z" },
                { "Link", "</link_previous>; rel=previous, </link_next>; rel=next, </link_self>; rel=self, </link_first>; rel=first, </link_last>; rel=last" },
                { "X-Rate-Limit-Limit", "600" },
                { "X-Result-Count", "50" },
                { "X-Result-Total", "1000" },
                { "X-Page-Size", "10" },
                { "X-Page-Total", "20" }
            };

            var response = new ApiV2HttpResponseInfo(statusCode, requestHeaders, responseHeaders);
            Assert.Equal(statusCode, response.ResponseStatusCode);
            Assert.Equal(new DateTime(2019, 5, 23, 22, 0, 0, DateTimeKind.Utc), response.Date.ToUniversalTime());
            Assert.Equal(new DateTime(2019, 5, 24, 0, 0, 0, DateTimeKind.Utc), response.Expires!.Value.ToUniversalTime());
            Assert.Equal(new DateTime(2019, 5, 23, 20, 0, 0, DateTimeKind.Utc), response.LastModified!.Value.ToUniversalTime());
            Assert.Equal(requestHeaders, response.RawRequestHeaders);
            Assert.Equal(responseHeaders, response.RawResponseHeaders);
            Assert.Equal(TimeSpan.FromSeconds(60), response.CacheMaxAge);
            Assert.Equal(new Dictionary<string, Uri>
            {
                { "previous", new Uri("/link_previous", UriKind.RelativeOrAbsolute) },
                { "next", new Uri("/link_next", UriKind.RelativeOrAbsolute) },
                { "self", new Uri("/link_self", UriKind.RelativeOrAbsolute) },
                { "first", new Uri("/link_first", UriKind.RelativeOrAbsolute) },
                { "last", new Uri("/link_last", UriKind.RelativeOrAbsolute) }
            }, response.Links);
            Assert.Equal(600, response.RateLimitLimit);
            Assert.Equal(50, response.ResultCount);
            Assert.Equal(1000, response.ResultTotal);
            Assert.Equal(10, response.PageSize);
            Assert.Equal(20, response.PageTotal);
        }

        [Fact]
        public void ConstructorIgnoresInvalidLinksTest()
        {
            var responseHeaders = new Dictionary<string, string>
            {
                { "Link", "</boop>; rel=invalid, illegal_format; nope, rel=next; rel=previous, <?rel=self>; rel=self" },
            };

            var response = new ApiV2HttpResponseInfo(HttpStatusCode.OK, null, responseHeaders);
            Assert.Equal(responseHeaders, responseHeaders);
            Assert.Equal(new Dictionary<string, Uri>
            {
                { "self", new Uri("?rel=self", UriKind.RelativeOrAbsolute) }
            }, response.Links);
        }

        [Fact]
        public void ConstructorIgnoresInvalidResponseHeadersTest()
        {
            var responseHeaders = new Dictionary<string, string>
            {
                { "Cache-Control", "public,max-age=NaN" },
                { "X-Rate-Limit-Limit", string.Empty },
                { "X-Result-Count", "2147483648" } // Int32.MaxValue + 1
            };

            var response = new ApiV2HttpResponseInfo(HttpStatusCode.OK, null, responseHeaders);
            Assert.Equal(responseHeaders, responseHeaders);
            Assert.Equal(default, response.CacheMaxAge);
            Assert.Equal(default, response.RateLimitLimit);
            Assert.Equal(default, response.ResultCount);
        }
    }
}
