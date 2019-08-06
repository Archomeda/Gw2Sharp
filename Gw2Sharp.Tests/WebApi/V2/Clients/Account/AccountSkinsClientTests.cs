using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountSkinsClientTests : BaseEndpointClientTests<IAccountSkinsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountSkinsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Skins;

        [Theory]
        [InlineData("TestFiles.Account.AccountSkins.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
