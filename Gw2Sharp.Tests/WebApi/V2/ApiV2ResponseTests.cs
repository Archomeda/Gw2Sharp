using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2
{
    public class ApiV2ResponseTests
    {
        [Fact]
        public void ConstructorTest()
        {
            string content = "content";
            var statusCode = HttpStatusCode.OK;
            var requestHeaders = new Dictionary<string, string>
            {
                { "X-Test", "Test" }
            };
            var responseHeaders = new Dictionary<string, string>
            {
                { "Cache-Control", "public,max-age=60" },
                { "Link", "</link_previous>; rel=previous, </link_next>; rel=next, </link_self>; rel=self, </link_first>; rel=first, </link_last>; rel=last" },
                { "X-Rate-Limit-Limit", "600" },
                { "X-Result-Count", "50" },
                { "X-Result-Total", "1000" },
                { "X-Page-Size", "10" },
                { "X-Page-Total", "20" }
            };

            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns(content);
            httpResponse.StatusCode.Returns(statusCode);
            httpResponse.RequestHeaders.Returns(requestHeaders);
            httpResponse.ResponseHeaders.Returns(responseHeaders);

            var response = new ApiV2Response<string>(httpResponse);
            Assert.Equal(content, response.Content);
            Assert.Equal(statusCode, response.StatusCode);
            Assert.Equal(requestHeaders, response.RequestHeaders);
            Assert.Equal(responseHeaders, response.ResponseHeaders);
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

            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns("");
            httpResponse.StatusCode.Returns(HttpStatusCode.OK);
            httpResponse.RequestHeaders.Returns(new Dictionary<string, string>());
            httpResponse.ResponseHeaders.Returns(responseHeaders);

            var response = new ApiV2Response<string>(httpResponse);
            Assert.Equal(responseHeaders, response.ResponseHeaders);
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
                { "X-Rate-Limit-Limit", null },
                { "X-Result-Count", "2147483648" } // Int32.MaxValue + 1
            };

            var httpResponse = Substitute.For<IHttpResponse>();
            httpResponse.Content.Returns("");
            httpResponse.StatusCode.Returns(HttpStatusCode.OK);
            httpResponse.RequestHeaders.Returns(new Dictionary<string, string>());
            httpResponse.ResponseHeaders.Returns(responseHeaders);

            var response = new ApiV2Response<string>(httpResponse);
            Assert.Equal(responseHeaders, response.ResponseHeaders);
            Assert.Equal(default, response.CacheMaxAge);
            Assert.Equal(default, response.RateLimitLimit);
            Assert.Equal(default, response.ResultCount);
        }

        [Fact]
        public void ImplicitConversionToContentType()
        {
            string expected = "content";
            var response = new ApiV2Response<string>
            {
                Content = expected
            };
            string actual = response;
            Assert.Equal(expected, actual);
        }
    }
}
