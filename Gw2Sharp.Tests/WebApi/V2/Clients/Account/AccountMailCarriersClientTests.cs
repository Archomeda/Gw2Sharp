using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMailCarriersClientTests : BaseEndpointClientTests<IAccountMailCarriersClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountMailCarriersClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.MailCarriers;

        [Theory]
        [InlineData("TestFiles.Account.AccountMailCarriers.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
