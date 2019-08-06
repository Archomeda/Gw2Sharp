using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountDailyCraftingClientTests : BaseEndpointClientTests<IAccountDailyCraftingClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountDailyCraftingClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.DailyCrafting;

        [Theory]
        [InlineData("TestFiles.Account.AccountDailyCrafting.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
