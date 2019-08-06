using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdClientTests : BaseEndpointClientTests<ICharactersIdClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"];

        [Theory]
        [InlineData("TestFiles.Characters.Characters.single.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);


        #region ArgumentNullException tests

        [Fact]
        public override void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                this.Client.GetType(),
                new[] { typeof(IConnection), typeof(IGw2Client), typeof(string) },
                new object[] { new Connection(), new Gw2Client(), "Bob" },
                new[] { true, true, false });
        }

        #endregion
    }
}
