using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class ContinentsFloorsRegionsMapsSectorsClientTests : BaseEndpointClientTests<IContinentsFloorsRegionsMapsSectorsClient>
    {
        protected override IContinentsFloorsRegionsMapsSectorsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Continents[1].Floors[0].Regions[1].Maps[1].Sectors;

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMapsSectors.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMapsSectors.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMapsSectors.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMapsSectors.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllDataAsync(this.Client, file);

        [Theory]
        [InlineData("TestFiles.Continents.ContinentsFloorsRegionsMapsSectors.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsDataAsync(this.Client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(int), typeof(int), typeof(int), typeof(int) },
                new object[] { new Connection(), new Gw2Client(), 1, 0, 1, 1 },
                new[] { true, true, false, false, false, false });
        }

        #endregion
    }
}
