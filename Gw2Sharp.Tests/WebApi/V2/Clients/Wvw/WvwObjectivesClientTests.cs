using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class WvwObjectivesClientTests : BaseEndpointClientTests<IWvwObjectivesClient>
    {
        protected override IWvwObjectivesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Wvw.Objectives;

        [Theory]
        [InlineData("TestFiles.Wvw.WvwObjectives.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwObjectives.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwObjectives.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Wvw.WvwObjectives.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);
    }
}
