using Gw2Sharp.WebApi.Http;
using NSubstitute;
using System;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class RequestExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IHttpRequest>();
            var response = Substitute.For<IHttpResponse>();
            var innerException = new NotImplementedException();
            string message = "test exception";


            var exception = new RequestException(request);
            var exception2 = new RequestException(request, response);
            var exception3 = new RequestException(request, message);
            var exception4 = new RequestException(request, response, message);
            var exception5 = new RequestException(request, message, innerException);
            var exception6 = new RequestException(request, response, message, innerException);

            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Null(exception.Response);

            Assert.Null(exception2.InnerException);
            Assert.Same(request, exception2.Request);
            Assert.Same(response, exception2.Response);

            Assert.Equal(message, exception3.Message);
            Assert.Null(exception3.InnerException);
            Assert.Same(request, exception3.Request);
            Assert.Null(exception3.Response);

            Assert.Equal(message, exception4.Message);
            Assert.Null(exception4.InnerException);
            Assert.Same(request, exception4.Request);
            Assert.Same(response, exception4.Response);

            Assert.Equal(message, exception5.Message);
            Assert.Same(innerException, exception5.InnerException);
            Assert.Same(request, exception5.Request);
            Assert.Null(exception5.Response);

            Assert.Equal(message, exception6.Message);
            Assert.Same(innerException, exception6.InnerException);
            Assert.Same(request, exception6.Request);
            Assert.Same(response, exception6.Response);
        }
    }
}
