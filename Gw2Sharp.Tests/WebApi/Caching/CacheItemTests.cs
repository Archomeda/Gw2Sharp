using System;
using System.Net;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class CacheItemTests
    {
        #region ArgumentNullException tests

        [Fact]
        public void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNull(
                () => new CacheItem("test category", "test id", "test item", HttpStatusCode.OK, DateTime.Now, CacheItemStatus.New, null),
                new[] { true, true, true, false, false, false, false });
        }

        #endregion
    }
}
