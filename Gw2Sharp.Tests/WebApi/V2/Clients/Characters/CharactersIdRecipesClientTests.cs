using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdRecipesClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdRecipesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdRecipesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Recipes;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdRecipes.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
