using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public static readonly object[] HeaderCases =
        {
            new[] { default(string) },
            new[] { "Accept-Language" },
            new[] { "Authorization" }
        };

        public static readonly object[] QueryWithManyCases =
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

        public static IEnumerable<object[]> HeaderWithQueryWithManyMatrixCases()
        {
            foreach (object[] header in HeaderCases)
            foreach (object[] queryWithMany in QueryWithManyCases)
                yield return header.Concat(queryWithMany).ToArray();
        }

        #endregion


        [Theory]
        [MemberAutoMockData(nameof(HeaderCases), ShareFixture = false)]
        public async Task SingleRequestAsyncTest(
            string responseHeaderNameToAdd,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture))] [Frozen] MiddlewareContext context,
            [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions());
            SetResponseHeader(response, responseHeaderNameToAdd, fixture.Create<string>());

            // Do the request
            var middleware = new CacheMiddleware();
            var liveResponse = await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));
            liveResponse.Should().BeSameAs(response);
        }

        [Theory]
        [MemberAutoMockData(nameof(HeaderCases), ShareFixture = false)]
        public async Task CachesSingleRequestAsyncTest(
            string responseHeaderNameToAdd,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture))] [Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture))] [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions());
            SetResponseHeader(response, responseHeaderNameToAdd, fixture.Create<string>());

            // Do the first request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Repeat the request to see if it's taken from the cache
            var cachedResponse = await middleware.OnRequestAsync(context, (r, t) => throw new InvalidOperationException("should not be hit"));
            cachedResponse.Should().BeEquivalentTo(response);
        }


        [Theory]
        [MemberAutoMockData(nameof(HeaderWithQueryWithManyMatrixCases), ShareFixture = false)]
        public async Task ManyRequestAsyncTest(
            string responseHeaderNameToAdd,
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture))] [Frozen] MiddlewareContext context,
            [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions(queryParams));
            SetResponseHeader(response, responseHeaderNameToAdd, fixture.Create<string>());
            SetResponseContent(response, responseElements);

            // Do the request
            var middleware = new CacheMiddleware();
            var liveResponse = await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Expect the response headers to contain the cache state
            response.ResponseHeaders["X-Gw2Sharp-Cache-State"] = CacheState.FromLive.ToString();

            liveResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [MemberAutoMockData(nameof(HeaderWithQueryWithManyMatrixCases), ShareFixture = false)]
        public async Task CachesManyRequestAsyncTest(
            string responseHeaderNameToAdd,
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture))] [Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture))] [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            context.Request.Options.Returns(CreateRequestOptions(queryParams));
            SetResponseHeader(response, responseHeaderNameToAdd, fixture.Create<string>());
            SetResponseContent(response, responseElements);

            // Do the first request
            var middleware = new CacheMiddleware();
            await middleware.OnRequestAsync(context, (r, t) => Task.FromResult(response));

            // Expect the response headers to contain the cache state
            response.ResponseHeaders["X-Gw2Sharp-Cache-State"] = CacheState.FromCache.ToString();

            // Repeat the request to see if it's taken from the cache
            var cachedResponse = await middleware.OnRequestAsync(context, (r, t) => throw new InvalidOperationException("should not be hit"));
            cachedResponse.Should().BeEquivalentTo(response);
        }

        [Theory]
        [MemberAutoMockData(nameof(HeaderWithQueryWithManyMatrixCases), ShareFixture = false)]
        public async Task CachesManyRequestSeparatelyAsyncTest(
            string responseHeaderNameToAdd,
            string queryParams,
            [Frozen] IList<Element> responseElements,
            [CustomizeWith(typeof(MemoryCacheMethodAutoFixture))] [Frozen] MiddlewareContext context,
            [CustomizeWith(typeof(ExpiresHeaderAutoFixture))] [Frozen] IWebApiResponse response,
            IFixture fixture)
        {
            var options = CreateRequestOptions(queryParams);
            context.Request.Options.Returns(options);
            SetResponseHeader(response, responseHeaderNameToAdd, fixture.Create<string>());
            SetResponseContent(response, responseElements);

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

        private static void SetResponseHeader(IWebApiResponse response, string headerName, string headerValue)
        {
            if (string.IsNullOrEmpty(headerName))
                return;

            if (response.ResponseHeaders is Dictionary<string, string> dictionary)
                dictionary[headerName] = headerValue;
            else
                response.ResponseHeaders.Returns(new Dictionary<string, string> { [headerName] = headerValue });
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
