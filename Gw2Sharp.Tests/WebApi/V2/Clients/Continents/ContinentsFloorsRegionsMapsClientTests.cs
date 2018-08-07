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
    public class ContinentsFloorsRegionsMapsClientTests : BaseEndpointClientTests
    {
        public ContinentsFloorsRegionsMapsClientTests()
        {
            var connection = new Connection(null, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Continents[1].Floors[0].Regions[1].Maps;
            this.Client = this.client;
        }

        private readonly IContinentsFloorsRegionsMapsClient client;

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMaps.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMaps.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMaps.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMaps.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMaps.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsData(this.client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(int), typeof(int), typeof(int) },
                new object[] { new Connection(), 1, 0, 1 },
                new[] { true, false, false, false });
        }

        #endregion
    }
}
