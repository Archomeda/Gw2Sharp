using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class PvpStatsClientTests : BaseEndpointClientTests<IPvpStatsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IPvpStatsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Pvp.Stats;

        [Theory]
        [InlineData("TestFiles.Pvp.PvpStats.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
