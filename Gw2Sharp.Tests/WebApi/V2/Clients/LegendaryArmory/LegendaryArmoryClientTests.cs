using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class LegendaryArmoryClientTests : BaseEndpointClientTests<ILegendaryArmoryClient>
    {
        protected override ILegendaryArmoryClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.LegendaryArmory;

        [Theory]
        [InlineData("TestFiles.LegendaryArmory.LegendaryArmory.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.LegendaryArmory.LegendaryArmory.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.LegendaryArmory.LegendaryArmory.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.LegendaryArmory.LegendaryArmory.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
