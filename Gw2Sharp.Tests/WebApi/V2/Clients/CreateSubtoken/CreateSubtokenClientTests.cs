using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CreateSubtokenClientTests : BaseEndpointClientTests<ICreateSubtokenClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICreateSubtokenClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.CreateSubtoken;

        [Theory]
        [InlineData("TestFiles.CreateSubtoken.CreateSubtoken.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
