using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class Coordinates2Tests
    {
        [Fact]
        public void ConstructorTest()
        {
            var coordinates = new Coordinates2(4, 2);
            Assert.Equal(4, coordinates.X);
            Assert.Equal(2, coordinates.Y);
            Assert.Equal(new[] { 4, 2 }, coordinates);
        }

        [Fact]
        public void DeserializeTest()
        {
            const string json = "[4,2]";
            var coordinates = JsonConvert.DeserializeObject<Coordinates2>(json);
            Assert.Equal(4, coordinates.X);
            Assert.Equal(2, coordinates.Y);
            Assert.Equal(new[] { 4, 2 }, coordinates);
        }

        [Fact]
        public void EqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(1, 2);
            Assert.True(coordinates.Equals((object)coordinates2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(2, 3);
            Assert.False(coordinates.Equals(coordinates2));
            Assert.False(coordinates.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(1, 2);
            Assert.True(coordinates == coordinates2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(2, 3);
            Assert.True(coordinates != coordinates2);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(1, 2);
            Assert.Equal(coordinates.GetHashCode(), coordinates2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var coordinates = new Coordinates2(1, 2);
            var coordinates2 = new Coordinates2(2, 3);
            Assert.NotEqual(coordinates.GetHashCode(), coordinates2.GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            var coordinates = new Coordinates2(5, 10);
            Assert.Equal("(5,10)", coordinates.ToString());
        }
    }
}
