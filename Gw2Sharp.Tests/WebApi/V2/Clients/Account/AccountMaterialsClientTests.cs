using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMaterialsClientTests : BaseEndpointClientTests
    {
        public AccountMaterialsClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Account.Materials;
            this.Client = this.client;
        }

        private readonly IAccountMaterialsClient client;

        [Theory]
        [InlineData("TestFiles.Account.AccountMaterials.json")]
        public Task BlobTest(string file) => this.AssertBlobData(this.client, file);
    }
}
