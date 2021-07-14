using System;
using System.Diagnostics;
using FluentAssertions;
using FluentAssertions.Execution;
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
            string version = new Version(FileVersionInfo.GetVersionInfo(typeof(Gw2Client).Assembly.Location).FileVersion).ToString(3);
            string expectedUserAgent = $"Gw2Sharp/{version} (https://github.com/Archomeda/Gw2Sharp)";

            var connection1 = new Connection();
            var connection2 = new Connection(key);
            var connection3 = new Connection(locale);
            var connection4 = new Connection(key, locale);
            var connection5 = new Connection(key, locale, httpClient: httpClient, cacheMethod: cacheMethod);
            var connection6 = new Connection(key, locale, userAgent: userAgent, httpClient: httpClient, cacheMethod: cacheMethod);
            var connection7 = new Connection(null!);
            var connection8 = new Connection(null!, Locale.English, httpClient: httpClient, cacheMethod: cacheMethod);

            using (new AssertionScope())
            {
                connection1.AccessToken.Should().BeEmpty();
                connection1.Locale.Should().Be(Locale.English);
                connection1.UserAgent.Should().Be(expectedUserAgent);
                connection1.HttpClient.Should().BeOfType<HttpClient>();
                connection1.CacheMethod.Should().BeOfType<MemoryCacheMethod>();

                connection2.AccessToken.Should().Be(key);
                connection2.Locale.Should().Be(Locale.English);
                connection2.UserAgent.Should().Be(expectedUserAgent);
                connection2.HttpClient.Should().BeOfType<HttpClient>();
                connection2.CacheMethod.Should().BeOfType<MemoryCacheMethod>();

                connection3.AccessToken.Should().BeEmpty();
                connection3.Locale.Should().Be(locale);
                connection3.UserAgent.Should().Be(expectedUserAgent);
                connection3.HttpClient.Should().BeOfType<HttpClient>();
                connection3.CacheMethod.Should().BeOfType<MemoryCacheMethod>();

                connection4.AccessToken.Should().Be(key);
                connection4.Locale.Should().Be(locale);
                connection4.UserAgent.Should().Be(expectedUserAgent);
                connection4.HttpClient.Should().BeOfType<HttpClient>();
                connection4.CacheMethod.Should().BeOfType<MemoryCacheMethod>();

                connection5.AccessToken.Should().Be(key);
                connection5.Locale.Should().Be(locale);
                connection5.UserAgent.Should().Be(expectedUserAgent);
                connection5.HttpClient.Should().Be(httpClient);
                connection5.CacheMethod.Should().Be(cacheMethod);

                connection6.AccessToken.Should().Be(key);
                connection6.Locale.Should().Be(locale);
                connection6.UserAgent.Should().Be($"{userAgent} {expectedUserAgent}");
                connection6.HttpClient.Should().Be(httpClient);
                connection6.CacheMethod.Should().Be(cacheMethod);

                connection7.AccessToken.Should().BeEmpty();

                connection8.UserAgent.Should().NotBeNullOrEmpty();
            }
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
