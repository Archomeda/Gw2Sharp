using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountLegendaryArmoryClientTests : BaseEndpointClientTests<IAccountLegendaryArmoryClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountLegendaryArmoryClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.LegendaryArmory;

        [Theory]
        [InlineData("TestFiles.Account.AccountLegendaryArmory.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
