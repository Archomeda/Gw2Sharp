using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class MountsSkinsClientTests : BaseEndpointClientTests
    {
        public MountsSkinsClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Mounts.Skins;
            this.Client = this.client;
        }

        private readonly IMountsSkinsClient client;

        [Theory]
        [InlineData("TestFiles.Mounts.MountsSkins.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Mounts.MountsSkins.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Mounts.MountsSkins.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Mounts.MountsSkins.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Mounts.MountsSkins.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.client, file);
    }
}
