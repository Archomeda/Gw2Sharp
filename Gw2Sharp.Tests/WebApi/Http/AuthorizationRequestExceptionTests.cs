using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Http
{
    public class AuthorizationRequiredExceptionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var request = Substitute.For<IHttpRequest>();
            var response = Substitute.For<IHttpResponse<ErrorObject>>();
            response.Content.Returns(new ErrorObject { Text = "Error" });
            var error = AuthorizationError.MissingScopes;

            var exception = new AuthorizationRequiredException(request, response, error);

            Assert.Null(exception.InnerException);
            Assert.Same(request, exception.Request);
            Assert.Same(response, exception.Response);
            Assert.Equal(error, exception.AuthorizationError);
        }

        [Fact]
        public void SerializableTest()
        {
            var request = new HttpRequest(new Uri("http://localhost"), new Dictionary<string, string> { { "hello", "tyria" } });
            var response = new HttpResponse<ErrorObject>(new ErrorObject { Text = "Error" }, HttpStatusCode.Forbidden, null, null);
            var error = AuthorizationError.MissingScopes;
            var exception = new AuthorizationRequiredException(request, response, error);
            exception.Should().BeBinarySerializable();
        }
    }
}
