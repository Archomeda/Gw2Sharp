using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdSabClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdSabClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdSabClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Sab;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdSab.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
