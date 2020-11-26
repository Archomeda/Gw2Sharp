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
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.Render;
        }

        private readonly IGw2WebApiRenderClient client;


        [Fact]
        public async Task DownloadToStreamTestAsync()
        {
            byte[] file = this.GetTestData("TestFiles.Render.414998.png");
            using var expectedMemoryStream = new MemoryStream(file, false);
            ((Gw2WebApiBaseClient)this.client).Connection.HttpClient.RequestStreamAsync(Arg.Any<IWebApiRequest>(), CancellationToken.None).Returns(callInfo =>
                new HttpResponseStream(expectedMemoryStream, HttpStatusCode.OK, CacheState.FromLive, null, null));

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
            ((Gw2WebApiBaseClient)this.client).Connection.HttpClient.RequestStreamAsync(Arg.Any<IWebApiRequest>(), CancellationToken.None).Returns(callInfo =>
                new HttpResponseStream(expectedMemoryStream, HttpStatusCode.OK, CacheState.FromLive, null, null));

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
                new[] { typeof(IConnection), typeof(IGw2Client) },
                new object[] { new Connection(), new Gw2Client() },
                new[] { true, true });
        }

        #endregion
    }
}
