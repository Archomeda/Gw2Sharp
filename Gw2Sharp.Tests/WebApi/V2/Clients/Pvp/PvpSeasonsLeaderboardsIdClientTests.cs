using System;
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
    public class PvpSeasonsLeaderboardsIdClientTests : BaseEndpointClientTests
    {
        public PvpSeasonsLeaderboardsIdClientTests()
        {
            var connection = new Connection(string.Empty, Locale.English, cacheMethod: new NullCacheMethod(), httpClient: Substitute.For<IHttpClient>());
            this.client = new Gw2Client(connection).WebApi.V2.Pvp.Seasons["11111111-2222-3333-4444-555555555555"].Leaderboards["ladder"];
            this.Client = this.client;
        }

        private readonly IPvpSeasonsLeaderboardsIdClient client;

        [Theory]
        [InlineData("TestFiles.Pvp.PvpLeaderboardsId.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(Guid), typeof(string) },
                new object[] { new Connection(), new Gw2Client(), Guid.Parse("11111111-2222-3333-4444-555555555555"), "ladder" },
                new[] { true, true, false, true });
        }

        #endregion
    }
}
