using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class StoriesSeasonsClientTests : BaseEndpointClientTests<IStoriesSeasonsClient>
    {
        protected override IStoriesSeasonsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Stories.Seasons;

        [Theory]
        [InlineData("TestFiles.Stories.StoriesSeasons.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Stories.StoriesSeasons.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Stories.StoriesSeasons.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Stories.StoriesSeasons.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Stories.StoriesSeasons.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
