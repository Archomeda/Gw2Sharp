using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
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
            var context = new MiddlewareContext(connection, request);
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns($"{{\"text\":\"{errorText}\"}}");
            response.StatusCode.Returns(statusCode);

            var middleware = new ExceptionMiddleware();

            using (new AssertionScope())
            {
                Func<Task> act = () => middleware.OnRequestAsync(context, (c, t) => Task.FromResult(response));
                var exception = (await act.Should().ThrowAsync<UnexpectedStatusException>()
                    .WithMessage(errorText))
                    .Which;

                exception.Response?.Content.Text.Should().Be(errorText);
                exception.Should().BeOfType(exceptionType);
            }
        }

        [Theory]
        [InlineData("<html><body>This is not JSON</body></html>", HttpStatusCode.InternalServerError, typeof(ServerErrorException))]
        public async Task ExceptionNoJsonRequestTest(string body, HttpStatusCode statusCode, Type exceptionType)
        {
            var connection = Substitute.For<IConnection>();
            var request = Substitute.For<IWebApiRequest>();
            var context = new MiddlewareContext(connection, request);
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns(body);
            response.StatusCode.Returns(statusCode);

            var middleware = new ExceptionMiddleware();

            using (new AssertionScope())
            {
                Func<Task> act = () => middleware.OnRequestAsync(context, (c, t) => Task.FromResult(response));
                var exception = (await act.Should().ThrowAsync<UnexpectedStatusException>()
                    .WithMessage(body))
                    .Which;

                exception.Response?.Content.Text.Should().Be(body);
                exception.Should().BeOfType(exceptionType);
            }
        }

        [Fact]
        public async Task UnexpectedStatusExceptionRequestTest()
        {
            const string MESSAGE = "Some nice error message";
            const string JSON = "{\"error\":\"" + MESSAGE + "\"}";

            var connection = Substitute.For<IConnection>();
            var request = Substitute.For<IWebApiRequest>();
            var context = new MiddlewareContext(connection, request);
            var response = Substitute.For<IWebApiResponse>();
            response.Content.Returns(JSON);
            response.StatusCode.Returns((HttpStatusCode)499);

            var middleware = new ExceptionMiddleware();

            Func<Task> act = () => middleware.OnRequestAsync(context, (c, t) => Task.FromResult(response));
            (await act.Should().ThrowAsync<UnexpectedStatusException>())
                .WithMessage(MESSAGE)
                .Which.Response?.Content.Message.Should().Be(MESSAGE);
        }
    }
}
