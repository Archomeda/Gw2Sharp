using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Render;
using NSubstitute;
using NSubstitute.Exceptions;
using Xunit;

namespace Gw2Sharp.Tests.WebApi
{
    public class RenderUrlTests
    {
        private readonly IGw2Client client;

        public RenderUrlTests()
        {
            this.client = Substitute.For<IGw2Client>();
            this.client.WebApi.Returns(Substitute.For<IGw2WebApiClient>());
            this.client.WebApi.Render.Returns(Substitute.For<IGw2WebApiRenderClient>());
        }

        [Theory]
        [InlineData("https://render.guildwars2.com/file/test/1234.png", null, "https://render.guildwars2.com/file/test/1234.png")]
        [InlineData("https://render.guildwars2.com/file/test/1234.png", "https://proxy.render.example.com/", "https://proxy.render.example.com/file/test/1234.png")]
        public void ConstructorTest(string url, string? hostnameReplacement, string expected)
        {
            var renderUrl = new RenderUrl(this.client, url, hostnameReplacement);

            Assert.Equal(expected, renderUrl.Url.ToString());
            Assert.Equal(expected, renderUrl.ToString());
            Assert.Equal(expected, renderUrl);
            Assert.Equal(this.client, renderUrl.Gw2Client);
        }

        [Fact]
        public async Task DownloadToByteArrayAsyncTest()
        {
            string url = "https://render.guildwars2.com/file/test/1234.png";
            byte[] expected = new byte[] { 0, 1, 2, 3, 4, 5 };
            this.client.WebApi.Render.DownloadToByteArrayAsync(Arg.Any<string>()).Returns(expected);
            this.client.WebApi.Render.DownloadToByteArrayAsync(Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(expected);
            this.client.WebApi.Render.DownloadToByteArrayAsync(Arg.Any<Uri>()).Returns(expected);
            this.client.WebApi.Render.DownloadToByteArrayAsync(Arg.Any<Uri>(), Arg.Any<CancellationToken>()).Returns(expected);

            var renderUrl = new RenderUrl(this.client, url, null);
            byte[] actual = await renderUrl.DownloadToByteArrayAsync();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DownloadToStreamAsyncTest()
        {
            string url = "https://render.guildwars2.com/file/test/1234.png";
            using var memoryStream = new MemoryStream();

            var renderUrl = new RenderUrl(this.client, url, null);
            await renderUrl.DownloadToStreamAsync(memoryStream);

            int notReceived = 0;
            try
            { await this.client.WebApi.Render.Received().DownloadToStreamAsync(memoryStream, Arg.Any<string>()); }
            catch (ReceivedCallsException) { notReceived++; }
            try
            { await this.client.WebApi.Render.Received().DownloadToStreamAsync(memoryStream, Arg.Any<string>(), Arg.Any<CancellationToken>()); }
            catch (ReceivedCallsException) { notReceived++; }
            try
            { await this.client.WebApi.Render.Received().DownloadToStreamAsync(memoryStream, Arg.Any<Uri>()); }
            catch (ReceivedCallsException) { notReceived++; }
            try
            { await this.client.WebApi.Render.Received().DownloadToStreamAsync(memoryStream, Arg.Any<Uri>(), Arg.Any<CancellationToken>()); }
            catch (ReceivedCallsException) { notReceived++; }
            Assert.NotEqual(4, notReceived);
        }
    }
}
