using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMapChestsClientTests : BaseEndpointClientTests<IAccountMapChestsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountMapChestsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.MapChests;

        [Theory]
        [InlineData("TestFiles.Account.AccountMapChests.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
