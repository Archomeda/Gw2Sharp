using System.ComponentModel;
using System.Text.Json;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class ApiEnumTests
    {
        [DefaultValue(EnumValue3)]
        public enum TestEnum
        {
            EnumValue1 = 0,
            EnumValue2,
            EnumValue3
        }

        private class JsonObject
        {
            public ApiEnum<TestEnum> Enum { get; set; } = default!;
        }

        [Fact]
        public void ConstructorTest()
        {
            var enum1 = new ApiEnum<TestEnum>(TestEnum.EnumValue2);
            var enum2 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, null);

            Assert.Equal(TestEnum.EnumValue2, enum1.Value);
            Assert.Equal(TestEnum.EnumValue2, enum2.Value);
        }

        [Theory]
        [InlineData("{\"Enum\":\"EnumValue2\"}", "EnumValue2", TestEnum.EnumValue2)]
        [InlineData("{\"Enum\":\"SomeRandomValue\"}", "SomeRandomValue", TestEnum.EnumValue3)]
        [InlineData("{\"Enum\":\"\"}", "", TestEnum.EnumValue3)]
        [InlineData("{\"Enum\":null}", null, null)]
        [InlineData("{}", null, null)]
        public void DeserializeTest(string json, string expectedRaw, TestEnum? expected)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ApiEnumConverter());
            var obj = JsonSerializer.Deserialize<JsonObject>(json, options);
            if (expected == null)
                Assert.Null(obj.Enum);
            else
            {
                Assert.Equal(expectedRaw, obj.Enum.RawValue);
                Assert.Equal(expected, obj.Enum.Value);
            }
        }

        [Theory]
        [InlineData(TestEnum.EnumValue1, "SomeRandomValue", true)]
        [InlineData(TestEnum.EnumValue1, "EnumValue1", false)]
        [InlineData(TestEnum.EnumValue1, "enumValue1", false)]
        [InlineData(TestEnum.EnumValue1, "enum_value_1", true)]
        public void IsUnknownTest(TestEnum @enum, string @string, bool expected)
        {
            var wrapper = new ApiEnum<TestEnum>(@enum, @string);
            Assert.Equal(expected, wrapper.IsUnknown);
        }

        [Fact]
        public void ImplicitConversionFromEnumTest()
        {
            var expected = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            ApiEnum<TestEnum> actual = TestEnum.EnumValue2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitConversionToEnumTest()
        {
            var expected = TestEnum.EnumValue2;
            TestEnum actual = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitConversionFromStringTest()
        {
            var expected = new ApiEnum<TestEnum>(TestEnum.EnumValue2);
            ApiEnum<TestEnum> actual = "EnumValue2";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitConversionToStringTest()
        {
            string expected = "SomeRawEnumValue";
            string actual = new ApiEnum<TestEnum>(TestEnum.EnumValue2, expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            string rawValue = "RawEnumValue1";
            var item = new ApiEnum<TestEnum>(TestEnum.EnumValue1, rawValue);
            Assert.Equal(rawValue, item.ToString());
        }

        [Fact]
        public void EqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.True(item1.Equals(item2));
        }

        [Fact]
        public void CaseInsensitiveEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, "enumValue1");
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, "Enumvalue1");
            Assert.True(item1.Equals(item2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString());
            var item3 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.False(item1.Equals(item2));
            Assert.False(item1.Equals(item3));
            Assert.False(item2.Equals(item3));
            Assert.False(item1.Equals(new object()));
            Assert.False(item1.Equals(null!));
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.Equal(item1.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void CaseInsensitiveHashCodeEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, "enumValue1");
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, "Enumvalue1");
            Assert.Equal(item1.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString());
            var item3 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.NotEqual(item1.GetHashCode(), item2.GetHashCode());
            Assert.NotEqual(item2.GetHashCode(), item3.GetHashCode());
            Assert.NotEqual(item1.GetHashCode(), item3.GetHashCode());
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.True(item1 == item2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var item1 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString());
            var item3 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.True(item1 != item2);
            Assert.True(item1 != item3);
            Assert.True(item2 != item3);
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
            Assert.True(item1 != new object());
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            Assert.True(item1 != null!);
        }
    }
}
