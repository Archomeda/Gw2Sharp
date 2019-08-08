using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdQuestsClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdQuestsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdQuestsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Quests;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdQuests.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
