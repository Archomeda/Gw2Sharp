using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountProgressionClientTests : BaseEndpointClientTests<IAccountProgressionClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountProgressionClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Progression;

        [Theory]
        [InlineData("TestFiles.Account.AccountProgression.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
