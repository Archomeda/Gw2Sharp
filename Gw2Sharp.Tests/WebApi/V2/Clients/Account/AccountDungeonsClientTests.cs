using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountDungeonsClientTests : BaseEndpointClientTests
    {
        public AccountDungeonsClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Account.Dungeons;
            this.Client = this.client;
        }

        private readonly IAccountDungeonsClient client;

        [Theory]
        [InlineData("TestFiles.Account.AccountDungeons.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);
    }
}