using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdSkillsClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdSkillsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdSkillsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Skills;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdSkills.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}