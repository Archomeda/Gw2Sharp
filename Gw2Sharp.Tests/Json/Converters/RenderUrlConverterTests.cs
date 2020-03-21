using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Render;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class RenderUrlConverterTests
    {
        private readonly IGw2Client client;

        public RenderUrlConverterTests()
        {
            this.client = Substitute.For<IGw2Client>();
            this.client.WebApi.Returns(Substitute.For<IGw2WebApiClient>());
            this.client.WebApi.Render.Returns(Substitute.For<IGw2WebApiRenderClient>());
        }

        [Fact]
        public void NoWriteTest()
        {
            var converter = new RenderUrlConverter(this.client);
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new RenderUrlConverter(this.client);
            Assert.True(converter.CanConvert(typeof(RenderUrl)));
        }
    }
}
