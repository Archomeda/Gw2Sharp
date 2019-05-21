using System;
using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildIdLogClientTests : BaseGuildSubEndpointClientTests
    {
        public GuildIdLogClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Guild["11111111-2222-3333-4444-555555555555"].Log;
            this.Client = this.client;
        }

        private IGuildIdLogClient client;

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdLog.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdLog.json")]
        public Task BlobSinceTest(string file)
        {
            this.client = this.client.Since(5);
            return this.AssertBlobDataAsync(this.client, file);
        }
    }
}
