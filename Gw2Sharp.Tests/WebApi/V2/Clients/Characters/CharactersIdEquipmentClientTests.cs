using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdEquipmentClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdEquipmentClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdEquipmentClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Equipment;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipment.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
