using System;
using System.Text.Json;
using FluentAssertions;
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

        [Theory]
        [InlineData("\"https://render.guildwars2.com/file/test/1234.png\"", "https://render.guildwars2.com/file/test/1234.png")]
        public void DeserializeCorrectly(string json, string expected)
        {
            var actual = JsonSerializer.Deserialize<RenderUrl>(json, new JsonSerializerOptions
            {
                Converters = { new RenderUrlConverter(this.client) }
            });

            actual.Url.AbsoluteUri.Should().Be(expected);
        }

        [Theory]
        [InlineData("2")]
        [InlineData("{}")]
        [InlineData("[]")]
        [InlineData("undefined")]
        public void DeserializeThrowsException(string json)
        {
            Action action = () => JsonSerializer.Deserialize<RenderUrl>(json, new JsonSerializerOptions
            {
                Converters = { new RenderUrlConverter(this.client) }
            });
            action.Should().Throw<JsonException>();
        }
    }
}
