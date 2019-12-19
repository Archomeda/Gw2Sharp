using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdEquipmentTabsClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdEquipmentTabsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdEquipmentTabsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].EquipmentTabs;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file, "tab");

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file, "tab", "tabs");

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file, "tabs");

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdEquipmentTabs.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
