using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountDyesClientTests : BaseEndpointClientTests<IAccountDyesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountDyesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Dyes;

        [Theory]
        [InlineData("TestFiles.Account.AccountDyes.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
