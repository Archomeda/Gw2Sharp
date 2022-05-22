using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
using NSubstitute;
using Objectivity.AutoFixture.XUnit2.AutoNSubstitute.Attributes;
using Objectivity.AutoFixture.XUnit2.Core.Attributes;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Middleware
{
    public class CacheMiddlewareTests
    {
        public class Element
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }


        #region Data

        public static readonly string[] HeadersToCacheSeparately = new[]
        {
            "Accept-Language",
            "Authorization"
        };

        public static readonly object[] QueryWithManyCases =
        {
            // All
            new[] { "ids=all" },
            // Many
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
            // Page
            new[] { "page=0" },
            // Page + custom page size
            new[] { "page=3&page_size=40" }
        };

        #endregion


        [Theory]
        [AutoMockData]
        public async Task SingleRequestAsyncTest(
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions());
            response.CacheState.Returns(CacheState.FromLive);

            // Do the request
            var middleware = new CacheMiddleware();
            var liveResponse = await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            liveResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [AutoMockData]
        public async Task CachesSingleRequestAsyncTest(
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture)), Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions());
            response.CacheState.Returns(CacheState.FromCache);

            // Do the first request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Repeat the request to see if it's taken from the cache
            var cachedResponse = await middleware.OnRequestAsync(context, (r, t) => throw new InvalidOperationException("should not be hit"));

            cachedResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [AutoMockData]
        public async Task CachesSingleRequestSeparatelyHeaderAsyncTest(
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture)), Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions());
            response.CacheState.Returns(CacheState.FromLive);

            // Do the first request without specific headers
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Repeat the request for every header to see if it's taken from live
            foreach (var cacheHeader in HeadersToCacheSeparately)
            {
                context.Request.Options.RequestHeaders = new Dictionary<string, string>()
                {
                    [cacheHeader] = fixture.Create<string>()
                };

                var nextMock = Substitute.For<Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>>();
                nextMock(Arg.Any<MiddlewareContext>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(response));
                await middleware.OnRequestAsync(context, nextMock);

                // Because the middleware passes the request to the next middleware if the response wasn't cached,
                // we can check here if that call has arrived
                await nextMock.Received(1)(Arg.Any<MiddlewareContext>(), Arg.Any<CancellationToken>());
            }
        }


        [Theory]
        [AutoMockData]
        public async Task ManyRequestAsyncTest(
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions(queryParams));
            SetResponseContent(response, responseElements);
            response.CacheState.Returns(CacheState.FromLive);

            // Do the request
            var middleware = new CacheMiddleware();
            var liveResponse = await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            liveResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [MemberAutoMockData(nameof(QueryWithManyCases), ShareFixture = false)]
        public async Task CachesManyRequestAsyncTest(
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture)), Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions(queryParams));
            SetResponseContent(response, responseElements);
            response.CacheState.Returns(CacheState.FromCache);

            // Do the first request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Repeat the request to see if it's taken from the cache
            var cachedResponse = await middleware.OnRequestAsync(context, (r, t) => throw new InvalidOperationException("should not be hit"));
            cachedResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [MemberAutoMockData(nameof(QueryWithManyCases), ShareFixture = false)]
        public async Task CachesManyRequestSeparatelyAsyncTest(
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture)), Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            var options = CreateRequestOptions(queryParams);
            context.Request.Options.Returns(options);
            SetResponseContent(response, responseElements);
            response.CacheState.Returns(CacheState.FromLive);

            // Do the first request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Do individual requests to see if they are taken from the cache
            options.EndpointQuery.Clear();
            foreach (var element in responseElements)
            {
                options.PathSuffix = element.Id;

                var elementResponse = await middleware.OnRequestAsync(context, (r, t) => throw new InvalidOperationException("should not be hit"));

                var elementObject = JsonSerializer.Deserialize<Element>(elementResponse.Content);
                elementObject.Should().BeEquivalentTo(element);
            }
        }


        [Theory]
        [MemberAutoMockData(nameof(QueryWithManyCases), ShareFixture = false)]
        public async Task CachesManyRequestSeparatelyHeaderAsyncTest(
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture)), Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture)), Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions(queryParams));
            SetResponseContent(response, responseElements);
            response.CacheState.Returns(CacheState.FromCache);

            // Do the first request without specific headers
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Repeat the request for every header to see if it's taken from live
            foreach (var cacheHeader in HeadersToCacheSeparately)
            {
                context.Request.Options.RequestHeaders = new Dictionary<string, string>()
                {
                    [cacheHeader] = fixture.Create<string>()
                };

                var nextMock = Substitute.For<Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>>();
                nextMock(Arg.Any<MiddlewareContext>(), Arg.Any<CancellationToken>()).Returns(x => Task.FromResult(response));
                await middleware.OnRequestAsync(context, nextMock);

                // Because the middleware passes the request to the next middleware if the response wasn't cached,
                // we can check here if that call has arrived
                await nextMock.Received(1)(Arg.Any<MiddlewareContext>(), Arg.Any<CancellationToken>());
            }
        }


        #region Helpers

        private static WebApiRequestOptions CreateRequestOptions(string queryParams = null)
        {
            var options = new WebApiRequestOptions
            {
                EndpointPath = "/some/endpoint"
            };
            if (!string.IsNullOrWhiteSpace(queryParams))
                options.EndpointQuery = queryParams.Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x.Skip(1).FirstOrDefault());
            return options;
        }

        private static void SetResponseContent<T>(IWebApiResponse response, T content)
        {
            string rawResponse = JsonSerializer.Serialize(content);
            response.Content.Returns(rawResponse);
        }

        #endregion


        #region AutoFixture customizations

        private class MemoryCacheMethodAutoFixture : ICustomization
        {
            public void Customize(IFixture fixture) =>
                fixture.Customizations.Add(new TypeRelay(typeof(ICacheMethod), typeof(MemoryCacheMethod)));
        }

        private class ExpiresHeaderAutoFixture : ICustomization
        {
            public void Customize(IFixture fixture) =>
                fixture.Customizations.Add(new ExpiresHeaderAutoFixtureBuilder());
        }

        private class ExpiresHeaderAutoFixtureBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                if (!(request is PropertyInfo propertyInfo))
                    return new NoSpecimen();

                if (!propertyInfo.DeclaringType.IsGenericType)
                    return new NoSpecimen();

                var genericType = propertyInfo.DeclaringType.GetGenericTypeDefinition();
                if (typeof(IWebApiResponse<>).IsAssignableFrom(genericType) && propertyInfo.Name == nameof(IWebApiResponse.ResponseHeaders))
                {
                    string expiresAt = 30.Minutes().After(DateTime.UtcNow).ToString("r");
                    var responseHeaders = new Dictionary<string, string>
                    {
                        ["Expires"] = expiresAt
                    };
                    return responseHeaders;
                }

                return new NoSpecimen();
            }
        }

        #endregion
    }
}
