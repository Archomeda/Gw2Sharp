using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountDungeonsClientTests : BaseEndpointClientTests<IAccountDungeonsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountDungeonsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Dungeons;

        [Theory]
        [InlineData("TestFiles.Account.AccountDungeons.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
