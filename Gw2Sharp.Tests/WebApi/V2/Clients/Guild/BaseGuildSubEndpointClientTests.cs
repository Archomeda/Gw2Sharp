using System;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public abstract class BaseGuildSubEndpointClientTests : BaseEndpointClientTests
    {
        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(Guid) },
                new object[] { new Connection(), Guid.Parse("11111111-2222-3333-4444-555555555555") },
                new[] { true, false });
        }

        #endregion
    }
}
