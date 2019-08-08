using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountAchievementsClientTests : BaseEndpointClientTests<IAccountAchievementsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountAchievementsClient CreateClient(IGw2Client gw2Client) =>
          gw2Client.WebApi.V2.Account.Achievements;

        [Theory]
        [InlineData("TestFiles.Account.AccountAchievements.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
