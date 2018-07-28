using Gw2Sharp.WebApi.Http;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class HttpClientExtensionsTests
    {
        [Fact]
        public void AddRangeTest()
        {
            var actualHeaders = (HttpRequestHeaders)Activator.CreateInstance(typeof(HttpRequestHeaders), true);
            actualHeaders.AddRange(new Dictionary<string, string>
            {
                { "Accept-Language", "en" },
                { "User-Agent", "TestAgent" }
            });

            var expectedHeaders = (HttpRequestHeaders)Activator.CreateInstance(typeof(HttpRequestHeaders), true);
            expectedHeaders.Add("Accept-Language", "en");
            expectedHeaders.Add("User-Agent", "TestAgent");

            Assert.Equal(expectedHeaders.AcceptLanguage, actualHeaders.AcceptLanguage);
            Assert.Equal(expectedHeaders.UserAgent, actualHeaders.UserAgent);
        }
    }
}
