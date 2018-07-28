using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CatsClientTests : BaseEndpointClientTests
    {
        public CatsClientTests()
        {
            var connection = new Connection(null, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Cats;
            this.Client = this.client;
        }

        private readonly ICatsClient client;

        [Theory]
        [InlineData("TestFiles.Cats.Cats.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Cats.Cats.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Cats.Cats.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Cats.Cats.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Cats.Cats.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsData(this.client, file);
    }
}
