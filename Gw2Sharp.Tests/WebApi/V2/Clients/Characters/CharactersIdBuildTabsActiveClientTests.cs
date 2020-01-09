using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdBuildTabsActiveClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdBuildTabsActiveClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdBuildTabsActiveClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].BuildTabs.Active;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdBuildTabs.single.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
