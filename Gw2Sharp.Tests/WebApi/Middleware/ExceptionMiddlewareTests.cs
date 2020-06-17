using System;
using System.Net;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
using Gw2Sharp.WebApi.V2.Models;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Theory]
        [InlineData("bad request", HttpStatusCode.BadRequest, typeof(BadRequestException))]
        [InlineData("Invalid access token", HttpStatusCode.Unauthorized, typeof(InvalidAccessTokenException))]
        [InlineData("authorization failed", HttpStatusCode.Forbidden, typeof(AuthorizationRequiredException))]
        [InlineData("invalid key", HttpStatusCode.Forbidden, typeof(InvalidAccessTokenException))]
        [InlineData("requires scope inventories", HttpStatusCode.Forbidden, typeof(MissingScopesException))]
        [InlineData("membership required", HttpStatusCode.Forbidden, typeof(MembershipRequiredException))]
        [InlineData("access restricted to guild leaders", HttpStatusCode.Forbidden, typeof(RestrictedToGuildLeadersException))]
        [InlineData("not found", HttpStatusCode.NotFound, typeof(NotFoundException))]
#if NET461
        [InlineData("too many requests", (HttpStatusCode)429, typeof(TooManyRequestsException))]
#else
        [InlineData("too many requests", HttpStatusCode.TooManyRequests, typeof(TooManyRequestsException))]
#endif
        [InlineData("server error", HttpStatusCode.InternalServerError, typeof(ServerErrorException))]
        [InlineData("service unavailable", HttpStatusCode.ServiceUnavailable, typeof(ServiceUnavailableException))]
        [InlineData("id list too long; this endpoint is limited to 200 ids at once", HttpStatusCode.BadRequest, typeof(ListTooLongException))]
        [InlineData("page out of range. Use page values 0 - 1175.", HttpStatusCode.BadRequest, typeof(PageOutOfRangeException))]
        public async Task ExceptionRequestTest(string errorText, HttpStatusCode statusCode, Type exceptionType)
        {
            var connection = Substitute.For<IConnection>();
            var request = Substitute.For<IWebApiRequest>();
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns($"{{\"text\":\"{errorText}\"}}");
            response.StatusCode.Returns(statusCode);

            var middleware = new ExceptionMiddleware();
            var exception = (UnexpectedStatusException<ErrorObject>)await Assert.ThrowsAsync(exceptionType,
                () => middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response)));
            Assert.Equal(errorText, exception.Response?.Content.Text);
        }

        [Fact]
        public async Task ExceptionNoJsonRequestTest()
        {
            const string BODY = "<html><body>This is not JSON</body></html>";

            var connection = Substitute.For<IConnection>();
            var request = Substitute.For<IWebApiRequest>();
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns(BODY);
            response.StatusCode.Returns(HttpStatusCode.InternalServerError);

            var middleware = new ExceptionMiddleware();
            var exception = await Assert.ThrowsAsync<UnexpectedStatusException>(() => middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response)));
            Assert.Equal(BODY, exception.Response?.Content);
        }

        [Fact]
        public async Task UnexpectedStatusExceptionRequestTest()
        {
            const string MESSAGE = "{\"error\":\"Some nice error message\"}";

            var connection = Substitute.For<IConnection>();
            var request = Substitute.For<IWebApiRequest>();
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns(MESSAGE);
            response.StatusCode.Returns((HttpStatusCode)499);

            var middleware = new ExceptionMiddleware();
            var exception = await Assert.ThrowsAsync<UnexpectedStatusException>(() => middleware.OnRequestAsync(connection, request, (r, t) => Task.FromResult(response)));
            Assert.Equal(MESSAGE, exception.Response?.Content);
        }
    }
}
