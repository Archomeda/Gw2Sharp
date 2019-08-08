using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildSearchNameClientTests : BaseGuildSubEndpointClientTests<IGuildSearchNameClient>
    {
        protected override IGuildSearchNameClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Guild.Search.Name("ArenaNet");

        [Theory]
        [InlineData("TestFiles.Guild.GuildSearch.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);

        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(string) },
                new object[] { new Connection(), new Gw2Client(), "name" },
                new[] { true, true, true });
        }

        #endregion
    }
}
