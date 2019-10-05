using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdSpecializationsClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdSpecializationsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdSpecializationsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Specializations;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdSpecializations.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}