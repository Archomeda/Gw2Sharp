using Gw2Sharp.Models;
using Newtonsoft.Json;
using Xunit;

namespace Gw2Sharp.Tests.Models
{
    public class Coordinates3Tests
    {
        [Fact]
        public void ConstructorTest()
        {
            var coordinates = new Coordinates3(4, 2, 8);
            Assert.Equal(4, coordinates.X);
            Assert.Equal(2, coordinates.Y);
            Assert.Equal(new[] { 4d, 2d, 8d }, coordinates);
        }

        [Fact]
        public void DeserializeTest()
        {
            const string json = "[4,2,1]";
            var coordinates = JsonConvert.DeserializeObject<Coordinates3>(json);
            Assert.Equal(4, coordinates.X);
            Assert.Equal(2, coordinates.Y);
            Assert.Equal(new[] { 4d, 2d, 1d }, coordinates);
        }

        [Fact]
        public void EqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(1, 2, 4);
            Assert.True(coordinates.Equals((object)Coordinates3));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(2, 3, 5);
            Assert.False(coordinates.Equals(Coordinates3));
            Assert.False(coordinates.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(1, 2, 4);
            Assert.True(coordinates == Coordinates3);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(2, 3, 5);
            Assert.True(coordinates != Coordinates3);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(1, 2, 4);
            Assert.Equal(coordinates.GetHashCode(), Coordinates3.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var coordinates = new Coordinates3(1, 2, 4);
            var Coordinates3 = new Coordinates3(2, 3, 5);
            Assert.NotEqual(coordinates.GetHashCode(), Coordinates3.GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            var coordinates = new Coordinates3(5, 10, 20);
            Assert.Equal("(5,10,20)", coordinates.ToString());
        }
    }
}
