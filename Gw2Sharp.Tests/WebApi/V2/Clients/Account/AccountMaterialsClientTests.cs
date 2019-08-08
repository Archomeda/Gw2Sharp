using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountMaterialsClientTests : BaseEndpointClientTests<IAccountMaterialsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountMaterialsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Materials;

        [Theory]
        [InlineData("TestFiles.Account.AccountMaterials.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
