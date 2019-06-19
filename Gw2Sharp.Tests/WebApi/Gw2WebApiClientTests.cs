using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.V2;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi
{
    public class Gw2WebApiClientTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var connection = Substitute.For<IConnection>();

            var client1 = new Gw2WebApiClient();
            var client2 = new Gw2WebApiClient(connection);

            Assert.IsType<Gw2WebApiV2Client>(client1.V2);

            Assert.Same(connection, ((IWebApiClientInternal)client2.V2.Account.Achievements).Connection);
            Assert.IsType<Gw2WebApiV2Client>(client2.V2);
        }
    }
}
