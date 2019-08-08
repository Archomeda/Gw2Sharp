using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommercePricesClientTests : BaseEndpointClientTests<ICommercePricesClient>
    {
        protected override ICommercePricesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Commerce.Prices;

        [Theory]
        [InlineData("TestFiles.Commerce.CommercePrices.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommercePrices.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommercePrices.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommercePrices.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
