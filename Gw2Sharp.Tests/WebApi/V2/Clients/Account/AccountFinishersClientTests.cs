
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountFinishersClientTests : BaseEndpointClientTests<IAccountFinishersClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountFinishersClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Finishers;

        [Theory]
        [InlineData("TestFiles.Account.AccountFinishers.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
