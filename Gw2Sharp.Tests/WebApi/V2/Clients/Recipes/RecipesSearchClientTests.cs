using System;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class RecipesSearchClientTests : BaseEndpointClientTests<IRecipesSearchClient>
    {
        protected override IRecipesSearchClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Recipes.Search;

        [Theory]
        [InlineData("TestFiles.Recipes.RecipesSearch.json")]
        public Task BlobInputTestAsync(string file)
        {
            var client = this.Client.Input(1234);
            return this.AssertBlobDataAsync(client, file);
        }

        [Theory]
        [InlineData("TestFiles.Recipes.RecipesSearch.json")]
        public Task BlobOutputTestAsync(string file)
        {
            var client = this.Client.Output(1234);
            return this.AssertBlobDataAsync(client, file);
        }

        [Fact]
        public Task BlobInvalidOperationTest() =>
            Assert.ThrowsAsync<InvalidOperationException>(() => this.Client.GetAsync());
    }
}
