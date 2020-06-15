using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Exceptions
{
    public class RequestCanceledExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IWebApiRequest>();
            var exception = new RequestCanceledException(request);

            Assert.NotNull(exception.Message);
            Assert.NotEqual(string.Empty, exception.Message);
            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Null(exception.Response);
        }
    }
}
