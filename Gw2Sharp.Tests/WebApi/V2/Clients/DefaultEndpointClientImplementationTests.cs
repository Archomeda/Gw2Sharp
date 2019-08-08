using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class DefaultEndpointClientImplementationTests
    {
        [Theory]
        [InlineData(null, null, "original", "original")]
        [InlineData(Locale.English, null, "original", "en_original")]
        [InlineData(null, "test-api-key", "original", "2E7A7EE14CAEBF378FC32D6CF6F557F347C96773_original")]
        [InlineData(Locale.English, "test-api-key", "original", "2E7A7EE14CAEBF378FC32D6CF6F557F347C96773_en_original")]
        public void FormatCacheIdTest(Locale? locale, string? accessToken, string originalCacheId, string expectedCacheId)
        {
            var endpointClient = Substitute.For<IEndpointClient>();
            var connection = new Connection(accessToken, locale ?? Locale.English);
            var gw2Client = Substitute.For<IGw2Client>();

            if (!string.IsNullOrEmpty(accessToken))
                endpointClient.IsAuthenticated.Returns(true);
            if (locale.HasValue)
                endpointClient.IsLocalized.Returns(true);

            var clientImplementation = new DefaultEndpointClientImplementation<TestBaseObject>(endpointClient, connection, gw2Client);
            string actualCacheId = clientImplementation.FormatCacheId(originalCacheId);
            Assert.Equal(expectedCacheId, actualCacheId);
        }


        #region ArgumentNullException tests

        private class TestBaseObject : ApiV2BaseObject { }

        [Fact]
        public virtual void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(
                typeof(DefaultEndpointClientImplementation<TestBaseObject>),
                new[] { typeof(IEndpointClient), typeof(IConnection), typeof(IGw2Client) },
                new object[] { Substitute.For<IEndpointClient>(), new Connection(), new Gw2Client() },
                new[] { true, true, true });
        }

        #endregion
    }
}
