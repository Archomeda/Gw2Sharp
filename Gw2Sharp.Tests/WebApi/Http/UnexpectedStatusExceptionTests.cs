using Gw2Sharp.WebApi.Http;
using NSubstitute;
using System;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class UnexpectedStatusExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IHttpRequest>();
            var response = Substitute.For<IHttpResponse>();
            string message = "test exception";

            var exception = new UnexpectedStatusException(request, response);
            var exception2 = new UnexpectedStatusException(request, response, message);

            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Same(response, exception.Response);

            Assert.Equal(message, exception2.Message);
            Assert.Null(exception2.InnerException);
            Assert.Same(request, exception2.Request);
            Assert.Same(response, exception2.Response);
        }
    }
}
