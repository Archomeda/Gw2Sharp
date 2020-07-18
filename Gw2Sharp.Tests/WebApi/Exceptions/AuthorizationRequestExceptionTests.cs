using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Exceptions
{
    public class AuthorizationRequiredExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IWebApiRequest>();
            var response = Substitute.For<IWebApiResponse<ErrorObject>>();
            response.Content.Returns(new ErrorObject { Text = "Error" });
            var error = AuthorizationError.MissingScopes;

            var exception = new AuthorizationRequiredException(request, response, error);

            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Same(response, exception.Response);
            Assert.Equal(error, exception.AuthorizationError);
        }
    }
}
