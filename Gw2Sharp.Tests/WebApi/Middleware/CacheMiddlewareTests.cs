using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoFixture;
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

            // Do the request
            var middleware = new CacheMiddleware();
            var finalResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));
            finalResponse.Should().BeSameAs(response);

            // Repeat the request to check for the header
            // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
            var cachedResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default));
            cachedResponse.Should().BeEquivalentTo(finalResponse);
        }

        public static readonly object[] ManyRequestsAsyncCases =
        {
            new[] { "ids=all" },
            new object[]
            {
                "ids=14,19,20",
                new[]
                {
                    new Element { Id = "14", Value = "Value14" },
                    new Element { Id = "19", Value = "Value19" },
                    new Element { Id = "20", Value = "Value20" }
                }
            },
            new[] { "page=0" },
            new[] { "page=3&page_size=40" }
        };

        [Theory]
        [MemberAutoMockData(nameof(ManyRequestsAsyncCases))]
        public async Task ManyRequestAsyncTest(string queryParams, [Frozen] IList<Element> responseElements,
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

            // Do the request
            var middleware = new CacheMiddleware();
            var finalResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));
            finalResponse.Should().BeSameAs(response);

            // Repeat the request to check for the header
            // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
            var cachedResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default));
            cachedResponse.Should().BeEquivalentTo(finalResponse);
        }

        [Theory]
        [AutoMockData]
        public async Task ReadsExpiresTest([Frozen] IConnection connection, [Frozen] IWebApiRequest request, [Frozen] IWebApiResponse response)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint"
            };
            request.Options.Returns(options);

            string expiresAt = 30.Minutes().After(DateTime.UtcNow).ToString("r");
            var responseHeaders = new Dictionary<string, string>
            {
                ["Expires"] = expiresAt
            };
            response.ResponseHeaders.Returns(responseHeaders);

            // Do the request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));

            // Repeat the request to check for the header
            // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
            var cachedResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default));
            cachedResponse.ResponseHeaders.Should().Contain(new KeyValuePair<string, string>("Expires", expiresAt));
        }

        [Theory]
        [InlineAutoMockData("Accept-Language")]
        [InlineAutoMockData("Authorization")]
        public async Task TakesHeaderIntoAccountForCachingSeparatelyTest(string headerName, IList<string> headerValues,
            [Frozen] IConnection connection, [Frozen] IWebApiRequest request, IFixture fixture)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint"
            };
            request.Options.Returns(options);

            var expiresAt = 30.Minutes().After(DateTime.UtcNow);
            var responseHeaders = new Dictionary<string, string>
            {
                ["Expires"] = expiresAt.ToString("r")
            };
            var response = fixture.Create<IWebApiResponse>();
            response.ResponseHeaders.Returns(responseHeaders);

            // Call the requests with different headers, the results should be different from each other
            var middleware = new CacheMiddleware();
            var finalResponseWithoutHeader = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));
            var finalResponsesWithHeader = new List<IWebApiResponse>();
            foreach (string headerValue in headerValues)
            {
                options.RequestHeaders.Clear();
                options.RequestHeaders[headerName] = headerValue;
                response = fixture.Create<IWebApiResponse>();
                response.ResponseHeaders.Returns(responseHeaders);

                finalResponsesWithHeader.Add(await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response)));
            }
            finalResponsesWithHeader.Should().NotContain(finalResponseWithoutHeader);
            finalResponsesWithHeader.Should().OnlyHaveUniqueItems();

            // Call the requests again to see if the responses are the same as the first ones
            options.RequestHeaders.Clear();

            // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
            var cachedFinalResponseWithoutHeader = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default));
            var cachedFinalResponsesWithHeader = new List<IWebApiResponse>();
            foreach (string headerValue in headerValues)
            {
                options.RequestHeaders.Clear();
                options.RequestHeaders[headerName] = headerValue;

                // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
                cachedFinalResponsesWithHeader.Add(await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default)));
            }
            cachedFinalResponseWithoutHeader.Should().BeSameAs(finalResponseWithoutHeader);
            cachedFinalResponsesWithHeader.Should().BeEquivalentTo(finalResponsesWithHeader);
        }

        public static readonly object[] ManyRequestCachesIndividualsFromManyRequestAsyncCases =
        {
            new object[]
            {
                null,
                new[]
                {
                    new Element { Id = "14", Value = "Value14" },
                    new Element { Id = "19", Value = "Value19" },
                    new Element { Id = "20", Value = "Value20" }
                }
            },
            new object[]
            {
                "Accept-Language",
                new[]
                {
                    new Element { Id = "14", Value = "Value14" },
                    new Element { Id = "19", Value = "Value19" },
                    new Element { Id = "20", Value = "Value20" }
                }
            },
            new object[]
            {
                "Authorization",
                new[]
                {
                    new Element { Id = "14", Value = "Value14" },
                    new Element { Id = "19", Value = "Value19" },
                    new Element { Id = "20", Value = "Value20" }
                }
            }
        };

        [Theory]
        [MemberAutoMockData(nameof(ManyRequestCachesIndividualsFromManyRequestAsyncCases))]
        public async Task TakesHeaderIntoAccountForCachingSeparatelyFromManyRequestAsyncTest(string? headerName, [Frozen] IList<Element> responseElements,
            string headerValue, [Frozen] IConnection connection, [Frozen] IWebApiRequest request, IFixture fixture)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint",
                EndpointQuery = new Dictionary<string, string> { ["ids"] = string.Join(",", responseElements.Select(x => x.Id)) }
            };
            if (!string.IsNullOrEmpty(headerName))
                options.RequestHeaders[headerName] = headerValue;
            request.Options.Returns(options);

            string expiresAt = 30.Minutes().After(DateTime.UtcNow).ToString("r");
            var responseHeaders = new Dictionary<string, string>
            {
                ["Expires"] = expiresAt
            };
            var response = fixture.Create<IWebApiResponse>();
            response.ResponseHeaders.Returns(responseHeaders);
            string rawResponse = JsonSerializer.Serialize(responseElements);
            response.Content.Returns(rawResponse);

            // Do the many request first
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response));

            // Do individual requests to see if they are taken from the cache
            options.EndpointQuery.Clear();
            foreach (var element in responseElements)
            {
                options.EndpointPath = "/some/endpoint";
                options.PathSuffix = element.Id;

                // The result in the callNext parameter shouldn't matter, if the cache is used, that Func shouldn't even be called
                var elementResponse = await middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult<IWebApiResponse>(default));

                elementResponse.ResponseHeaders.Should().Contain(new KeyValuePair<string, string>("Expires", expiresAt));
                var elementObject = JsonSerializer.Deserialize<Element>(elementResponse.Content);
                elementObject.Should().BeEquivalentTo(element);
            }
        }
    }
}
