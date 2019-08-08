using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdTrainingClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdTrainingClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdTrainingClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Training;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdTraining.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
