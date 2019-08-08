using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildIdLogClientTests : BaseGuildSubEndpointClientTests<IGuildIdLogClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IGuildIdLogClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Guild["11111111-2222-3333-4444-555555555555"].Log;

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdLog.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdLog.json")]
        public Task BlobSinceTest(string file)
        {
            var client = this.Client.Since(5);
            return this.AssertBlobDataAsync(client, file);
        }
    }
}
