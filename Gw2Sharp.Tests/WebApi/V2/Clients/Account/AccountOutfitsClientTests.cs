using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountOutfitsClientTests : BaseEndpointClientTests<IAccountOutfitsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountOutfitsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Outfits;

        [Theory]
        [InlineData("TestFiles.Account.AccountOutfits.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
