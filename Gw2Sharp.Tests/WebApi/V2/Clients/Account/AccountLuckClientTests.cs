using System;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    [Obsolete("Deprecated since 2021-09-28. This will be removed from Gw2Sharp starting from version 2.0.")]
    public class AccountLuckClientTests : BaseEndpointClientTests<IAccountLuckClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountLuckClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Luck;

        [Theory]
        [InlineData("TestFiles.Account.AccountLuck.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
