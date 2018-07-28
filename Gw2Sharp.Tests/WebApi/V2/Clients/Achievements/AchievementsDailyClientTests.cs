using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AchievementsDailyClientTests : BaseEndpointClientTests
    {
        public AchievementsDailyClientTests()
        {
            var connection = new Connection(null, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Achievements.Daily;
            this.Client = this.client;
        }

        private readonly IAchievementsDailyClient client;

        [Theory]
        [InlineData("TestFiles.Achievements.AchievementsDaily.json")]
        public Task BlobTest(string file) => this.AssertBlobData(this.client, file);
    }
}
