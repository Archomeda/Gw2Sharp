using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CommerceExchangeGemsClientTests : BaseCommerceExchangeClientTests
    {
        public CommerceExchangeGemsClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Commerce.Exchange.Gems.Quantity(10);
            this.Client = this.client;
        }

        private readonly ICommerceExchangeGemsQuantityClient client;

        [Theory]
        [InlineData("TestFiles.Commerce.CommerceExchangeGems.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);
    }
}
