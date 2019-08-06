using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMasteriesClientTests : BaseEndpointClientTests<IAccountMasteriesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountMasteriesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Masteries;

        [Theory]
        [InlineData("TestFiles.Account.AccountMasteries.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
