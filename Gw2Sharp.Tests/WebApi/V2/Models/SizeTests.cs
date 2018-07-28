using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class SizeTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var size = new Size(4, 2);
            Assert.Equal(4, size.Width);
            Assert.Equal(2, size.Height);
        }

        [Fact]
        public void DeserializeTest()
        {
            string json = "[4,2]";
            var size = JsonConvert.DeserializeObject<Size>(json);
            Assert.Equal(4, size.Width);
            Assert.Equal(2, size.Height);
        }

        [Fact]
        public void EqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(1, 2);
            Assert.True(size.Equals((object)size2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(2, 3);
            Assert.False(size.Equals(size2));
            Assert.False(size.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(1, 2);
            Assert.True(size == size2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(2, 3);
            Assert.True(size != size2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(1, 2);
            Assert.Equal(size.GetHashCode(), size2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var size = new Size(1, 2);
            var size2 = new Size(2, 3);
            Assert.NotEqual(size.GetHashCode(), size2.GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            var size = new Size(5, 10);
            Assert.Equal("(5,10)", size.ToString());
        }
    }
}
