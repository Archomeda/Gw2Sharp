using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AchievementsDailyClientTests : BaseEndpointClientTests<IAchievementsDailyClient>
    {
        protected override IAchievementsDailyClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Achievements.Daily;

        [Theory]
        [InlineData("TestFiles.Achievements.AchievementsDaily.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
