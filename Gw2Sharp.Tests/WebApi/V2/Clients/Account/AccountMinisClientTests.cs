using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMinisClientTests : BaseEndpointClientTests<IAccountMinisClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountMinisClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Minis;

        [Theory]
        [InlineData("TestFiles.Account.AccountMinis.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
