using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountGlidersClientTests : BaseEndpointClientTests<IAccountGlidersClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountGlidersClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Gliders;

        [Theory]
        [InlineData("TestFiles.Account.AccountGliders.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
