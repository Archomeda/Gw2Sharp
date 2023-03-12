using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class HttpClientTests
    {
        [Fact]
        public async Task RequestTest()
        {
            string message = "Hello world";
            (string headerKey, string headerValue) = ("X-Test", "Hello world");

            using var server = WireMockServer.Start();
            server
                .Given(Request
                    .Create()
                    .WithPath("/")
                    .UsingGet())
                .RespondWith(Response
                    .Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithHeader(headerKey, headerValue)
                    .WithBody(message));

            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = server.Url,
                RequestHeaders = new Dictionary<string, string> { { headerKey, headerValue } }
            });

            var result = await client.RequestAsync(request, CancellationToken.None);

            Assert.Equal(message, result.Content);
            Assert.Contains(new KeyValuePair<string, string>(headerKey, headerValue), result.ResponseHeaders);
        }

        [Fact]
        public async Task RequestCanceledTest()
        {
            using var server = WireMockServer.Start();
            server
                .Given(Request
                    .Create()
                    .WithPath("/")
                    .UsingGet())
                .RespondWith(Response
                    .Create()
                    .WithDelay(TimeSpan.FromSeconds(2))
                    .WithStatusCode(HttpStatusCode.OK));

            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = server.Url,
                RequestHeaders = new Dictionary<string, string>()
            });

            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            await Assert.ThrowsAsync<RequestCanceledException>(() => client.RequestAsync(request, tokenSource.Token));
        }

        [Fact]
        public async Task RequestUnexpectedStatusTest()
        {
            using var server = WireMockServer.Start();
            server
                .Given(Request
                    .Create()
                    .WithPath("/")
                    .UsingGet())
                .RespondWith(Response
                    .Create()
                    .WithStatusCode(HttpStatusCode.NotFound));

            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = server.Url,
                RequestHeaders = new Dictionary<string, string>()
            });

            var result = await client.RequestAsync(request, CancellationToken.None);
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
