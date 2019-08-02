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
    public class CharactersIdClientTests : BaseEndpointClientTests
    {
        public CharactersIdClientTests()
        {
            var connection = new Connection("12345678-1234-1234-1234-12345678901234567890-1234-1234-1234-123456789012", Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Characters["Bob"];
            this.Client = this.client;
        }

        private readonly ICharactersIdClient client;

        [Theory]
        [InlineData("TestFiles.Characters.Characters.single.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(string) },
                new object[] { new Connection(), new Gw2Client(), "Bob" },
                new[] { true, true, false });
        }

        #endregion
    }
}
