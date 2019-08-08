using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceListingsClientTests : BaseEndpointClientTests<ICommerceListingsClient>
    {
        protected override ICommerceListingsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Commerce.Listings;

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceListings.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceListings.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceListings.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceListings.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
