using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountHomeCatsClientTests : BaseEndpointClientTests<IAccountHomeCatsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountHomeCatsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Home.Cats;

        [Theory]
        [InlineData("TestFiles.Account.AccountHomeCats.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
