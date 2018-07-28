using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Gw2SharpTests.WebApi.V2
{
    public class RequestBuilderTests
    {
        /*
        private class FakeWebClient : HttpClient { }

        private class FakeCacheMethod : MemoryCacheMethod { }

        protected RequestBuilder builder;

        public RequestBuilderTests()
        {
            this.builder = new RequestBuilder(Substitute.For<IRequest>());
        }

        [Fact]
        public void SetApiKeyTest()
        {
            const string key = "some test key woo";

            this.builder.DefaultAuthentication = key;
            Assert.Equal(key, this.builder.DefaultAuthentication);
            this.builder.Authenticate(null);
            Assert.Equal(key, this.builder.DefaultAuthentication);
        }

        [Fact]
        public void SetLocaleTest()
        {
            const Locale locale = Locale.German;

            this.builder.DefaultLanguage = locale;
            Assert.Equal(locale, this.builder.DefaultLanguage);
            this.builder.Language(Locale.French);
            Assert.Equal(locale, this.builder.DefaultLanguage);
        }

        [Fact]
        public void SetWebClientTest()
        {
            var webClient = Substitute.For<IHttpClient>();

            this.builder.DefaultWebClient = webClient;
            Assert.Same(webClient, this.builder.DefaultWebClient);
            this.builder.UseWebClient<FakeWebClient>();
            Assert.Same(webClient, this.builder.DefaultWebClient);
        }

        [Fact]
        public void SetCacheMethodTest()
        {
            var cacheMethod = Substitute.For<ICacheMethod>();

            this.builder.DefaultCacheMethod = cacheMethod;
            Assert.Same(cacheMethod, this.builder.DefaultCacheMethod);
            this.builder.UseCacheMethod<FakeCacheMethod>();
            Assert.Same(cacheMethod, this.builder.DefaultCacheMethod);
        }

        public static IEnumerable<object[]> Endpoints = new List<object[]>
        {
            new object[] { "Continents", typeof(EndpointBuilder<ContinentsClient>) },
            new object[] { "Maps", typeof(EndpointBuilder<MapsClient>) }
        };

        [Theory]
        [MemberData(nameof(Endpoints))]
        public void CreateTest(string methodName, Type type)
        {
            string key = "api key";
            var locale = Locale.German;
            var webClient = Substitute.For<IHttpClient>();
            var cacheMethod = Substitute.For<ICacheMethod>();

            var builder = this.builder.Authenticate(key).Language(locale).UseWebClient(webClient).UseCacheMethod(cacheMethod);
            MethodInfo method = typeof(RequestBuilder).GetMethod(methodName);
            object result = method.Invoke(builder, null);

            Assert.Equal(key, type.GetProperty("DefaultAuthentication").GetValue(result));
            Assert.Equal(locale, type.GetProperty("DefaultLanguage").GetValue(result));
            Assert.Same(webClient, type.GetProperty("DefaultWebClient").GetValue(result));
            Assert.Same(cacheMethod, type.GetProperty("DefaultCacheMethod").GetValue(result));
        }

        [Theory]
        [MemberData(nameof(Endpoints))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void CreateDoesNotOverrideDefaultTest(string methodName, Type type)
        {
            string key = "api key";
            var locale = Locale.German;
            var webClient = Substitute.For<IHttpClient>();
            var cacheMethod = Substitute.For<ICacheMethod>();

            this.builder.DefaultAuthentication = key;
            this.builder.DefaultLanguage = locale;
            this.builder.DefaultWebClient = webClient;
            this.builder.DefaultCacheMethod = cacheMethod;
            var builder = this.builder
                .Authenticate("some different key")
                .Language(Locale.French)
                .UseWebClient(Substitute.For<IHttpClient>())
                .UseCacheMethod(Substitute.For<ICacheMethod>());
            MethodInfo method = typeof(RequestBuilder).GetMethod(methodName);
            method.Invoke(builder, null);

            Assert.Equal(key, builder.DefaultAuthentication);
            Assert.Equal(locale, builder.DefaultLanguage);
            Assert.Same(webClient, builder.DefaultWebClient);
            Assert.Same(cacheMethod, builder.DefaultCacheMethod);
        }
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        */
    }
}
