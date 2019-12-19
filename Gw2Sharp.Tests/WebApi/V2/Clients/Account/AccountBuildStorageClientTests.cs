using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountBuildStorageClientTests : BaseEndpointClientTests<IAccountBuildStorageClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountBuildStorageClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.BuildStorage;

        [Theory]
        [InlineData("TestFiles.Account.AccountBuildStorage.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Account.AccountBuildStorage.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Account.AccountBuildStorage.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Account.AccountBuildStorage.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Account.AccountBuildStorage.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
