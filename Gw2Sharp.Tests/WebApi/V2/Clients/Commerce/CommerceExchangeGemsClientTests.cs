using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceExchangeGemsClientTests : BaseCommerceExchangeClientTests<ICommerceExchangeGemsQuantityClient>
    {
        protected override ICommerceExchangeGemsQuantityClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Commerce.Exchange.Gems.Quantity(10);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceExchangeGems.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
