using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildSearchNameClientTests : BaseGuildSubEndpointClientTests
    {
        public GuildSearchNameClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2WebApiClient(connection).V2.Guild.Search.Name("ArenaNet");
            this.Client = this.client;
        }

        private readonly IGuildSearchNameClient client;

        [Theory]
        [InlineData("TestFiles.Guild.GuildSearch.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);

        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(string) },
                new object[] { new Connection(), "name" },
                new[] { true, true });
        }

        #endregion
    }
}
