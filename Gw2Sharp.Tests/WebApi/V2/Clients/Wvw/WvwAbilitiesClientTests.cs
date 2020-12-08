using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class WvwAbilitiesClientTests : BaseEndpointClientTests<IWvwAbilitiesClient>
    {
        protected override IWvwAbilitiesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Wvw.Abilities;

        [Theory]
        [InlineData("TestFiles.Wvw.WvwAbilities.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwAbilities.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwAbilities.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwAbilities.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
