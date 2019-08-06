using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceExchangeCoinsClientTests : BaseCommerceExchangeClientTests<ICommerceExchangeCoinsQuantityClient>
    {
        protected override ICommerceExchangeCoinsQuantityClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Commerce.Exchange.Coins.Quantity(100000);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceExchangeCoins.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
