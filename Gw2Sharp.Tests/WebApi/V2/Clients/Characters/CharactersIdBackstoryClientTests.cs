using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdBackstoryClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdBackstoryClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdBackstoryClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Backstory;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdBackstory.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
