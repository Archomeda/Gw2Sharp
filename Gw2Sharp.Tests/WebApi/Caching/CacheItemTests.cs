using System;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class CacheItemTests
    {
        [Fact]
        public void EqualsTest()
        {
            var item = new CacheItem<string>("test category", "test id", "test item", DateTime.Now);
            Assert.True(item.Equals(item));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var item = new CacheItem<string>("test category", "test id", "test item", DateTime.Now);
            var item2 = new CacheItem<string>("test category 2", "test id 2", "test item 2", DateTime.Now);
            Assert.False(item.Equals(item2));
            Assert.False(item.Equals(new object()));
            Assert.False(item.Equals(null!));
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var date = DateTime.Now;
            var item = new CacheItem<string>("test category", "test id", "test item", date);
            var item2 = new CacheItem<string>("test category", "test id", "test item", date);
            Assert.Equal(item.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var item = new CacheItem<string>("test category", "test id", "test item", DateTime.Now);
            var item2 = new CacheItem<string>("test category 2", "test id 2", "test item 2", DateTime.Now);
            Assert.NotEqual(item.GetHashCode(), item2.GetHashCode());
        }

        #region ArgumentNullException tests

        [Fact]
        public void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNull(
                () => new CacheItem("test category", "test id", "test item", DateTime.Now),
                new[] { true, true, true, false });
            AssertArguments.ThrowsWhenNull(
                () => new CacheItem<string>("test category", "test id", "test item", DateTime.Now),
                new[] { true, true, true, false });
        }

        #endregion
    }
}
