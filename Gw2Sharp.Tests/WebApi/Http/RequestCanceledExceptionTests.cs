using System;
using System.Collections.Generic;
using FluentAssertions;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class RequestCanceledExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IHttpRequest>();
            var exception = new RequestCanceledException(request);

            Assert.NotNull(exception.Message);
            Assert.NotEqual(string.Empty, exception.Message);
            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Null(exception.Response);
        }

        [Fact]
        public void SerializableTest()
        {
            var request = new HttpRequest(new Uri("http://localhost"), new Dictionary<string, string> { { "hello", "tyria" } });
            var exception = new RequestCanceledException(request);
            exception.Should().BeBinarySerializable();
        }
    }
}
