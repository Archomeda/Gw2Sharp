using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountEmotesClientTests : BaseEndpointClientTests<IAccountEmotesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountEmotesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Emotes;

        [Theory]
        [InlineData("TestFiles.Account.AccountEmotes.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
