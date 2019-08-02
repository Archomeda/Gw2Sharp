using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceTransactionsHistoryBuysClientTests : BaseEndpointClientTests
    {
        public CommerceTransactionsHistoryBuysClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Commerce.Transactions.History.Buys;
            this.Client = this.client;
        }

        private readonly ICommerceTransactionsHistoryBuysClient client;

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceTransactionsHistory.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceTransactionsHistory.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.client, file);
    }
}