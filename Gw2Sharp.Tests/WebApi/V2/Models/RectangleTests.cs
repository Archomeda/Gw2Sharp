using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class RectangleTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            Assert.Equal(new Coordinates2(2, 4), rectangle.TopLeft);
            Assert.Equal(new Coordinates2(6, 4), rectangle.TopRight);
            Assert.Equal(new Coordinates2(2, 8), rectangle.BottomLeft);
            Assert.Equal(new Coordinates2(6, 8), rectangle.BottomRight);
            Assert.Equal(new[] { new[] { 2d, 4d }, new[] { 6d, 8d } }, rectangle);

            rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.BottomUp);
            Assert.Equal(new Coordinates2(2, 8), rectangle.TopLeft);
            Assert.Equal(new Coordinates2(6, 8), rectangle.TopRight);
            Assert.Equal(new Coordinates2(2, 4), rectangle.BottomLeft);
            Assert.Equal(new Coordinates2(6, 4), rectangle.BottomRight);
            Assert.Equal(new[] { new[] { 2d, 4d }, new[] { 6d, 8d } }, rectangle);
        }

        [Fact]
        public void DeserializeTest()
        {
            string json = "[[2,4],[6,8]]";
            var rectangle = JsonConvert.DeserializeObject<Rectangle>(json, new TopDownRectangleConverter());
            Assert.Equal(new Coordinates2(2, 4), rectangle.TopLeft);
            Assert.Equal(new Coordinates2(6, 4), rectangle.TopRight);
            Assert.Equal(new Coordinates2(2, 8), rectangle.BottomLeft);
            Assert.Equal(new Coordinates2(6, 8), rectangle.BottomRight);
            Assert.Equal(new[] { new[] { 2d, 4d }, new[] { 6d, 8d } }, rectangle);

            json = "[[2,4],[6,8]]";
            rectangle = JsonConvert.DeserializeObject<Rectangle>(json, new BottomUpRectangleConverter());
            Assert.Equal(new Coordinates2(2, 8), rectangle.TopLeft);
            Assert.Equal(new Coordinates2(6, 8), rectangle.TopRight);
            Assert.Equal(new Coordinates2(2, 4), rectangle.BottomLeft);
            Assert.Equal(new Coordinates2(6, 4), rectangle.BottomRight);
            Assert.Equal(new[] { new[] { 2d, 4d }, new[] { 6d, 8d } }, rectangle);
        }

        [Fact]
        public void SizeTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 10), RectangleDirectionType.TopDown);
            Assert.Equal(4, rectangle.Width);
            Assert.Equal(6, rectangle.Height);
        }

        [Fact]
        public void EqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            Assert.True(rectangle.Equals((object)rectangle2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(4, 6), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle3 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(4, 6), RectangleDirectionType.TopDown);
            var rectangle4 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.BottomUp);
            Assert.False(rectangle.Equals(rectangle2));
            Assert.False(rectangle.Equals(rectangle3));
            Assert.False(rectangle.Equals(rectangle4));
            Assert.False(rectangle.Equals(null));
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            Assert.True(rectangle == rectangle2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(4, 6), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle3 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(4, 6), RectangleDirectionType.TopDown);
            var rectangle4 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.BottomUp);
            Assert.True(rectangle != rectangle2);
            Assert.True(rectangle != rectangle3);
            Assert.True(rectangle != rectangle4);
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            Assert.Equal(rectangle.GetHashCode(), rectangle2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle2 = new Rectangle(new Coordinates2(4, 6), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            var rectangle3 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(4, 6), RectangleDirectionType.TopDown);
            var rectangle4 = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.BottomUp);
            Assert.NotEqual(rectangle.GetHashCode(), rectangle2.GetHashCode());
            Assert.NotEqual(rectangle.GetHashCode(), rectangle3.GetHashCode());
            Assert.NotEqual(rectangle.GetHashCode(), rectangle4.GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            var rectangle = new Rectangle(new Coordinates2(2, 4), new Coordinates2(6, 8), RectangleDirectionType.TopDown);
            Assert.Equal($"((2,4),(6,4),(2,8),(6,8))", rectangle.ToString());
        }
    }
}
