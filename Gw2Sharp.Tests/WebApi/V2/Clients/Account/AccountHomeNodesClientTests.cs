using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountHomeNodesClientTests : BaseEndpointClientTests
    {
        public AccountHomeNodesClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Account.Home.Nodes;
            this.Client = this.client;
        }

        private readonly IAccountHomeNodesClient client;

        [Theory]
        [InlineData("TestFiles.Account.AccountHomeNodes.json")]
        public Task BlobTest(string file) => this.AssertBlobData(this.client, file);
    }
}
