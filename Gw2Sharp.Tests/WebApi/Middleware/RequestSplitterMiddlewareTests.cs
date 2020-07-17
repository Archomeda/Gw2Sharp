using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Middleware
{
    public class RequestSplitterMiddlewareTests
    {
        public class Element
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("value")] public string Value { get; set; }
        }

        [Fact]
        public void MaxRequestSizeIsAtLeastOneTest()
        {
            var middleware = new RequestSplitterMiddleware();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => middleware.MaxRequestSize = 0);
        }

        [Theory]
        [AutoMockData]
        public async Task RequestIsSplitIfMoreThanMaxTest([Frozen] MiddlewareContext context)
        {
            var options = new WebApiRequestOptions
            {
                BulkQueryParameterIdsName = "ids",
                EndpointPath = "/some/endpoint",
                EndpointQuery = new Dictionary<string, string>
                {
                    ["ids"] = "K1,K2,K3"
                }
            };
            context.Request.Options.Returns(options);
            var elements = new[]
            {
                new Element { Id = "K1", Value = "V1" },
                new Element { Id = "K2", Value = "V2" },
                new Element { Id = "K3", Value = "V3" }
            };

            var middleware = new RequestSplitterMiddleware { MaxRequestSize = 2 };
            var response = await middleware.OnRequestAsync(context, (c, t) =>
            {
                var ids = c.Request.Options.EndpointQuery["ids"].Split(',');
                ids.Should().HaveCountLessOrEqualTo(middleware.MaxRequestSize);

                var innerElements = ids.Select(x => elements.First(y => y.Id == x));
                IWebApiResponse innerResponse = new WebApiResponse(JsonSerializer.Serialize(innerElements));
                return Task.FromResult(innerResponse);
            });

            var actual = JsonSerializer.Deserialize<IList<Element>>(response.Content);
            actual.Should().BeEquivalentTo(elements);
        }

        [Theory]
        [InlineAutoMockData(3)]
        [InlineAutoMockData(4)]
        public async Task RequestIsNotSplitIfLessThanOrEqualToMaxTest(int maxRequestSize, [Frozen] MiddlewareContext context)
        {
            var options = new WebApiRequestOptions
            {
                BulkQueryParameterIdsName = "ids",
                EndpointPath = "/some/endpoint",
                EndpointQuery = new Dictionary<string, string>
                {
                    ["ids"] = "K1,K2,K3"
                }
            };
            context.Request.Options.Returns(options);
            var elements = new[]
            {
                new Element { Id = "K1", Value = "V1" },
                new Element { Id = "K2", Value = "V2" },
                new Element { Id = "K3", Value = "V3" }
            };

            var middleware = new RequestSplitterMiddleware { MaxRequestSize = maxRequestSize };
            var response = await middleware.OnRequestAsync(context, (c, t) =>
            {
                var ids = c.Request.Options.EndpointQuery["ids"].Split(',');
                ids.Should().HaveCountLessOrEqualTo(middleware.MaxRequestSize);
                ids.Should().BeEquivalentTo(elements.Select(x => x.Id));

                IWebApiResponse innerResponse = new WebApiResponse(JsonSerializer.Serialize(elements));
                return Task.FromResult(innerResponse);
            });

            var actual = JsonSerializer.Deserialize<IList<Element>>(response.Content);
            actual.Should().BeEquivalentTo(elements);
        }

        [Theory]
        [AutoMockData]
        public async Task RequestIsNotSplitNotBulkTest([Frozen] MiddlewareContext context, [Frozen] IWebApiResponse response, Element element)
        {
            var options = new WebApiRequestOptions
            {
                BulkQueryParameterIdsName = "ids",
                EndpointPath = "/some/endpoint",
                EndpointQuery = new Dictionary<string, string>()
            };
            context.Request.Options.Returns(options);
            string rawResponse = JsonSerializer.Serialize(element);
            response.Content.Returns(rawResponse);

            var middleware = new RequestSplitterMiddleware();
            var finalResponse = await middleware.OnRequestAsync(context, (c, t) => Task.FromResult(response));
            finalResponse.Should().BeEquivalentTo(response);
        }
    }
}
