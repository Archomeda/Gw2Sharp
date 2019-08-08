using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public abstract class BaseCommerceExchangeClientTests<T> : BaseEndpointClientTests<T> where T : IEndpointClient
    {

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
