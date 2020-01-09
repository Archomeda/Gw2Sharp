using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdEquipmentTabsActiveClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdEquipmentTabsActiveClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdEquipmentTabsActiveClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].EquipmentTabs.Active;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.single.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
