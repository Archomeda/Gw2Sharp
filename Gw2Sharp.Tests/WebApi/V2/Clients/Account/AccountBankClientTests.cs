using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountBankClientTests : BaseEndpointClientTests<IAccountBankClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountBankClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Bank;

        [Theory]
        [InlineData("TestFiles.Account.AccountBank.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
