using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountTitlesClientTests : BaseEndpointClientTests<IAccountTitlesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountTitlesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Titles;

        [Theory]
        [InlineData("TestFiles.Account.AccountTitles.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
