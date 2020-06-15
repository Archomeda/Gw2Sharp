using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Middleware
{
    public class CacheMiddlewareTests
    {
        public class Element
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("value")] public string Value { get; set; }
        }

        [Theory]
        [AutoMockData]
        public async Task SingleRequestAsyncTest([Frozen] IConnection connection, [Frozen] IWebApiRequest request, [Frozen] IWebApiResponse response)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint"
            };
            request.Options.Returns(options);

            var middleware = new CacheMiddleware();
            var finalResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));
            finalResponse.Should().BeSameAs(response);

            var cachedItem = await connection.CacheMethod.TryGetAsync<IWebApiResponse>(options.EndpointPath, "_index");
            cachedItem.Item.Should().BeSameAs(finalResponse);
        }

        public static readonly object[] ManyRequestsAsyncCases =
        {
            new[] { "ids=all", "_all" },
            new object[]
            {
                "ids=14,19,20",
                null,
                new[]
                {
                    new Element { Id = "14", Value = "Value14" },
                    new Element { Id = "19", Value = "Value19" },
                    new Element { Id = "20", Value = "Value20" }
                }
            },
            new[] { "page=0", "_page0-" },
            new[] { "page=3&page_size=40", "_page3-40" }
        };

        [Theory]
        [MemberAutoMockData(nameof(ManyRequestsAsyncCases))]
        public async Task ManyRequestAsyncTest(string queryParams, string? fullCacheId, [Frozen] IList<Element> responseElements,
            [Frozen] IConnection connection, [Frozen] IWebApiRequest request, [Frozen] IWebApiResponse response)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint",
                EndpointQuery = queryParams.Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x.Skip(1).FirstOrDefault())
            };
            request.Options.Returns(options);
            string rawResponse = JsonSerializer.Serialize(responseElements);
            response.Content.Returns(rawResponse);

            var middleware = new CacheMiddleware();
            var finalResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));
            finalResponse.Should().BeSameAs(response);

            var cachedItems = await Task.WhenAll(responseElements.Select(x => connection.CacheMethod.TryGetAsync<IWebApiResponse>(options.EndpointPath, x.Id)));
            cachedItems.Select(x => x.Item.Content).Should().BeEquivalentTo(responseElements.Select(x => JsonSerializer.Serialize(x)));

            if (fullCacheId != null)
            {
                var fullCachedItem = await connection.CacheMethod.TryGetAsync<IWebApiResponse>(options.EndpointPath, fullCacheId);
                fullCachedItem.Item.Should().BeSameAs(finalResponse);
            }
        }

        [Theory]
        [AutoMockData]
        public async Task ExpiresTest([Frozen] IConnection connection, [Frozen] IWebApiRequest request, [Frozen] IWebApiResponse response)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint"
            };
            request.Options.Returns(options);

            var expiresAt = 30.Minutes().After(DateTime.UtcNow);
            var headers = new Dictionary<string, string>
            {
                ["Expires"] = expiresAt.ToString("r")
            };
            response.ResponseHeaders.Returns(headers);

            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));

            var cachedItem = await connection.CacheMethod.TryGetAsync<IWebApiResponse>(options.EndpointPath, "_index");
            cachedItem.ExpiryTime.Should().BeSameDateAs(expiresAt);
        }
    }
}
