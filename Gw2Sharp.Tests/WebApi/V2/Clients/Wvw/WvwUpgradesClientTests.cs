using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class WvwUpgradesClientTests : BaseEndpointClientTests<IWvwUpgradesClient>
    {
        protected override IWvwUpgradesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Wvw.Upgrades;

        [Theory]
        [InlineData("TestFiles.Wvw.WvwUpgrades.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwUpgrades.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwUpgrades.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwUpgrades.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
