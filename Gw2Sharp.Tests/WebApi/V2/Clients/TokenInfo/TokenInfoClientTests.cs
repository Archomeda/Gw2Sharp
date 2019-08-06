using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class TokenInfoClientTests : BaseEndpointClientTests<ITokenInfoClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ITokenInfoClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.TokenInfo;

        [Theory]
        [InlineData("TestFiles.TokenInfo.TokenInfo.ApiToken.json")]
        [InlineData("TestFiles.TokenInfo.TokenInfo.SubToken.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
