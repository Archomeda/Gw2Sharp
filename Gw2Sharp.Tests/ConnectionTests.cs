using System;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            string key = "test key";
            var locale = Locale.German;
            string userAgent = "HelloTyria";
            var httpClient = Substitute.For<IHttpClient>();
            var cacheMethod = Substitute.For<ICacheMethod>();

            var connection1 = new Connection();
            var connection2 = new Connection(key);
            var connection3 = new Connection(locale);
            var connection4 = new Connection(key, locale);
            var connection5 = new Connection(key, locale, httpClient: httpClient, cacheMethod: cacheMethod);
            var connection6 = new Connection(key, locale, userAgent: userAgent, httpClient: httpClient, cacheMethod: cacheMethod);
            var connection7 = new Connection(null!);
            var connection8 = new Connection(null!, Locale.English, httpClient: httpClient, cacheMethod: cacheMethod);

            Assert.Equal(string.Empty, connection1.AccessToken);
            Assert.Equal(Locale.English, connection1.Locale);
            Assert.IsType<HttpClient>(connection1.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection1.CacheMethod);

            Assert.Equal(key, connection2.AccessToken);
            Assert.Equal(Locale.English, connection2.Locale);
            Assert.IsType<HttpClient>(connection2.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection2.CacheMethod);

            Assert.Equal(string.Empty, connection3.AccessToken);
            Assert.Equal(locale, connection3.Locale);
            Assert.IsType<HttpClient>(connection3.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection3.CacheMethod);

            Assert.Equal(key, connection4.AccessToken);
            Assert.Equal(locale, connection4.Locale);
            Assert.IsType<HttpClient>(connection4.HttpClient);
            Assert.IsType<MemoryCacheMethod>(connection4.CacheMethod);

            Assert.Equal(key, connection5.AccessToken);
            Assert.Equal(locale, connection5.Locale);
            Assert.Same(httpClient, connection5.HttpClient);
            Assert.Same(cacheMethod, connection5.CacheMethod);

            Assert.Equal(key, connection6.AccessToken);
            Assert.Equal(locale, connection6.Locale);
            Assert.StartsWith(userAgent, connection6.UserAgent);
            Assert.True(connection6.UserAgent.Length > userAgent.Length);
            Assert.Same(httpClient, connection6.HttpClient);
            Assert.Same(cacheMethod, connection6.CacheMethod);

            Assert.Equal(string.Empty, connection7.AccessToken);
            Assert.NotEqual(string.Empty, connection8.UserAgent);
        }

        [Theory]
        [InlineData("55BCD46F-B57C-469A-AE81-3B21B5583573", true)]
        [InlineData("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c", true)]
        [InlineData("\"", false)]
        public void ValidAccessTokenTest(string accessToken, bool isValid)
        {
            if (!isValid)
                Assert.Throws<ArgumentException>("accessToken", () => new Connection(accessToken));
            else
                new Connection(accessToken); // Should not throw

            var connection = new Connection();
            if (!isValid)
                Assert.Throws<ArgumentException>("value", () => connection.AccessToken = accessToken);
            else
                connection.AccessToken = accessToken; // Should not throw
        }

        [Theory]
        [InlineData("en", Locale.English)]
        [InlineData("de", Locale.German)]
        [InlineData("fr", Locale.French)]
        [InlineData("es", Locale.Spanish)]
        [InlineData("ko", Locale.Korean)]
        [InlineData("zh", Locale.Chinese)]
        public void LocaleStringTest(string expected, Locale locale)
        {
            // Maybe find a way to store strings inside enums and test that feature instead,
            // so we don't have to manually test every enum with custom string values in existence.
            var connection = new Connection(locale);
            Assert.Equal(expected, connection.LocaleString);
        }
    }
}
