using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountRecipesClientTests : BaseEndpointClientTests<IAccountRecipesClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountRecipesClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Recipes;

        [Theory]
        [InlineData("TestFiles.Account.AccountRecipes.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
