using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.Http;
using Xunit;

namespace Gw2SharpTests.WebApi.V2
{
    public class RequestTests
    {
        /*
        private class FakeWebClient : HttpClient { }

        private class FakeCacheMethod : MemoryCacheMethod { }

        protected Request request;

        public RequestTests()
        {
            this.request = new Request();
        }

        [Fact]
        public void SetApiKeyTest()
        {
            const string key = "some test key woo";

            var request2 = this.request.Authenticate(key);
            Assert.Same(this.request, request2);
            Assert.Equal(key, this.request.ApiKey);
        }

        [Fact]
        public void SetLocaleTest()
        {
            const Locale locale = Locale.German;

            var request2 = this.request.Language(locale);
            Assert.Same(this.request, request2);
            Assert.Equal(locale, this.request.Locale);
        }

        [Fact]
        public void SetCacheMethodTest()
        {
            var request2 = this.request.UseCacheMethod<FakeCacheMethod>();
            Assert.Same(this.request, request2);
            Assert.IsType<FakeCacheMethod>(this.request.CacheMethod);
        }

        [Fact]
        public void SetWebClientTest()
        {
            var request2 = this.request.UseWebClient<FakeWebClient>();
            Assert.Same(this.request, request2);
            Assert.IsType<FakeWebClient>(this.request.WebClient);
        }

        [Fact]
        public void CloneTest()
        {
            this.request.ApiKey = "test key";
            var request2 = this.request.Clone();
            Assert.NotSame(this.request, request2);
            Assert.Equal(this.request.ApiKey, request2.ApiKey);
        }
        */
    }
}
