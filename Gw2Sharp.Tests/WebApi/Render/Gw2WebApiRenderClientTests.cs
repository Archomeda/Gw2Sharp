using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Render;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Render
{
    public class Gw2WebApiRenderClientTests
    {
        public Gw2WebApiRenderClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).Render;
        }

        private readonly IGw2WebApiRenderClient client;


        [Fact]
        public async Task DownloadToStreamTestAsync()
        {
            byte[] file = this.GetTestData("TestFiles.Render.414998.png");
            using var expectedMemoryStream = new MemoryStream(file, false);
            ((IWebApiClientInternal)this.client).Connection.HttpClient.RequestStreamAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                return new HttpResponseStream(expectedMemoryStream, HttpStatusCode.OK, null, null);
            });

            using var actualMemoryStream = new MemoryStream();
            await this.client.DownloadToStreamAsync(actualMemoryStream, "https://should.not.matter/");
            byte[] actual = actualMemoryStream.ToArray();

            Assert.Equal(file, actual);
        }

        [Fact]
        public async Task DownloadToByteArrayTestAsync()
        {
            byte[] file = this.GetTestData("TestFiles.Render.414998.png");
            using var expectedMemoryStream = new MemoryStream(file, false);
            ((IWebApiClientInternal)this.client).Connection.HttpClient.RequestStreamAsync(Arg.Any<IHttpRequest>(), CancellationToken.None).Returns(callInfo =>
            {
                return new HttpResponseStream(expectedMemoryStream, HttpStatusCode.OK, null, null);
            });

            byte[] actual = await this.client.DownloadToByteArrayAsync("https://should.not.matter/");
            Assert.Equal(file, actual);
        }


        protected byte[] GetTestData(string fileResourceName)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Gw2Sharp.Tests.{fileResourceName}");
            if (stream == null)
                throw new FileNotFoundException($"Resource {fileResourceName} does not exist");

            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }


        #region ArgumentNullException tests

        [Fact]
        public virtual void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.client.GetType(),
                new[] { typeof(IConnection) },
                new[] { new Connection() },
                new[] { true });
        }

        #endregion
    }
}
