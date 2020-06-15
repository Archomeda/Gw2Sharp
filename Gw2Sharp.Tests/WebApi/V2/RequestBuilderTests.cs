using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
            var httpResponse = Substitute.For<IWebApiResponse>();
            httpResponse.Content.Returns("{\"testkey\":\"testvalue\"}");
            httpResponse.StatusCode.Returns(HttpStatusCode.OK);
            httpResponse.ResponseHeaders.Returns(new Dictionary<string, string> { { "response", "here" } });
            httpClient.RequestAsync(Arg.Any<IWebApiRequest>(), CancellationToken.None).Returns(Task.FromResult(httpResponse));
            var content = new TestContentClass { Testkey = "testvalue" };

            var connection = new Connection(string.Empty, default, new NullCacheMethod(), httpClient: httpClient);
            var request = new WebApiRequest(new WebApiRequestOptions
            {
                BaseUrl = "http://localhost",
                EndpointPath = "endpoint",
                BulkQueryParameterIdName = "id",
                BulkQueryParameterIdsName = "ids"
            }, connection, Substitute.For<IGw2Client>());
            var response = await new RequestBuilder(Substitute.For<IEndpointClient>(), connection, Substitute.For<IGw2Client>())
                .Blob()
                .ExecuteAsync<TestContentClass>();

            Assert.Equal(content.Testkey, response.Content.Testkey);
            Assert.Equal(httpResponse.StatusCode, response.StatusCode);
            Assert.Equal(httpResponse.ResponseHeaders, response.ResponseHeaders);
        }


        public class TestContentClass
        {
            public string Testkey { get; set; } = string.Empty;
        }
    }
}
