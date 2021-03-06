using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class HttpClientTests
    {
        protected const string Url = "http://localhost:12345/";

        protected HttpListener CreateOneTimeListener(Func<HttpListenerContext, bool> func)
        {
            var listener = new HttpListener();
            new Thread(() =>
            {
                listener.Prefixes.Add(Url);
                listener.Start();
                var context = listener.GetContext();

                // This is here to provide test methods the option to "cancel" the response
                if (func(context))
                    context.Response.Close();
            }).Start();

            while (!listener.IsListening)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            return listener;
        }

        [Fact]
        public async Task RequestTest()
        {
            string message = "Hello world";
            (string headerKey, string headerValue) = ("X-Test", "Hello world");

            using var listener = this.CreateOneTimeListener(context =>
            {
                var buf = Encoding.UTF8.GetBytes(message);
                context.Response.AddHeader(headerKey, headerValue);
                context.Response.OutputStream.Write(buf, 0, buf.Length);
                return true;
            });
            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = Url,
                RequestHeaders = new Dictionary<string, string> { { headerKey, headerValue } }
            });

            var result = await client.RequestAsync(request, CancellationToken.None);

            Assert.Equal(message, result.Content);
            Assert.Contains(new KeyValuePair<string, string>(headerKey, headerValue), result.ResponseHeaders);
        }

        [Fact]
        public async Task RequestCanceledTest()
        {
            var reset = new ManualResetEvent(false);

            using var listener = this.CreateOneTimeListener(context =>
            {
                reset.WaitOne();
                return false;
            });
            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = Url,
                RequestHeaders = new Dictionary<string, string>()
            });

            var tokenSource = new CancellationTokenSource(1000);
            await Assert.ThrowsAsync<RequestCanceledException>(() => client.RequestAsync(request, tokenSource.Token));
            reset.Set();
        }

        [Fact]
        public async Task RequestUnexpectedStatusTest()
        {
            using var listener = this.CreateOneTimeListener(context =>
            {
                context.Response.StatusCode = 404;
                return true;
            });
            var client = new HttpClient();
            var request = Substitute.For<IWebApiRequest>();
            request.Options.Returns(new WebApiRequestOptions
            {
                BaseUrl = Url,
                RequestHeaders = new Dictionary<string, string>()
            });

            var result = await client.RequestAsync(request, CancellationToken.None);
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
