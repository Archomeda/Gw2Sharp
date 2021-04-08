using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersClientTests : BaseEndpointClientTests<ICharactersClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters;

        [Theory]
        [InlineData("TestFiles.Characters.Characters.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Characters.Characters.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file, "name");

        [Theory]
        [InlineData("TestFiles.Characters.Characters.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file, "name");

        [Theory]
        [InlineData("TestFiles.Characters.Characters.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Characters.Characters.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);

#pragma warning disable CS0618
        [Theory]
        [InlineData("TestFiles.Characters.Characters.EquipmentTabs.json")]
        [InlineData("TestFiles.Characters.Characters.EquipmentTabs.Null.json")]
        public async Task EquipmentPvpRollForwardTest(string file)
        {
            // This roll-forward capability will be removed from Gw2Sharp starting with version 2.0
            var actual = await this.AssertGetDataAsync(this.Client, file, "name");
            actual.EquipmentPvp.Should().BeEquivalentTo(actual.EquipmentTabs?.Single(x => x.Tab == actual.ActiveEquipmentTab).EquipmentPvp);
        }
#pragma warning restore CS0618
    }
}
