using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdCraftingClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdCraftingClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdCraftingClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Crafting;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdCrafting.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
