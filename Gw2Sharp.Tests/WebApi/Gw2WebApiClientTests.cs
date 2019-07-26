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
            var gw2Client = Substitute.For<IGw2Client>();

            var client = new Gw2WebApiClient(connection, gw2Client);

            Assert.Same(connection, ((IClientInternal)client.V2.Account.Achievements).Connection);
            Assert.IsType<Gw2WebApiV2Client>(client.V2);
        }
    }
}
