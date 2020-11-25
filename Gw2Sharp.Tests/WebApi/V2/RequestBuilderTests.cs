using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2
{
    public class RequestBuilderTests
    {
        [Fact]
        public async Task ValidRequestTest()
        {
            var httpClient = Substitute.For<IHttpClient>();
            var httpResponse = new WebApiResponse(
                "{\"testkey\":\"testvalue\"}",
                HttpStatusCode.OK,
                CacheState.FromLive,
                new Dictionary<string, string> { { "response", "here" } });
            httpClient.RequestAsync(Arg.Any<IWebApiRequest>()).Returns(_ => httpResponse);
            var content = new TestContentClass { Testkey = "testvalue" };

            var connection = new Connection(string.Empty, default, new NullCacheMethod(), httpClient: httpClient);
            var response = await new RequestBuilder(Substitute.For<IEndpointClient>(), connection, Substitute.For<IGw2Client>())
                .Blob()
                .ExecuteAsync<TestContentClass>();

            response.Content.Should().BeEquivalentTo(content);
            response.StatusCode.Should().Be(httpResponse.StatusCode);
            response.CacheState.Should().Be(CacheState.FromLive);
            response.ResponseHeaders.Should().Contain(httpResponse.ResponseHeaders);
        }


        public class TestContentClass
        {
            public string Testkey { get; set; } = string.Empty;
        }
    }
}
