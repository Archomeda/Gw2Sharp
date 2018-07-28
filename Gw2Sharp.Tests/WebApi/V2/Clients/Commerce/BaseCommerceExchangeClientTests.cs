using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public abstract class BaseCommerceExchangeClientTests : BaseEndpointClientTests
    {

        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(int) },
                new object[] { new Connection(), 42 },
                new[] { true, false });
        }

        #endregion
    }
}
