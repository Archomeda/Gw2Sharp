using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class RecipesSearchOutputClientTests : BaseEndpointClientTests<IRecipesSearchOutputClient>
    {
        protected override IRecipesSearchOutputClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Recipes.Search.Output(1234);

        [Theory]
        [InlineData("TestFiles.Recipes.RecipesSearch.json")]
        public Task BlobTestAsync(string file) => this.AssertBlobDataAsync(this.Client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(int) },
                new object[] { new Connection(), new Gw2Client(), 42 },
                new[] { true, true, false });
        }

        #endregion
    }
}
