using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
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
            public ApiEnum<TestEnum> Enum { get; set; }
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
        [InlineData("{\"Enum\":undefined}", "EnumValue3", TestEnum.EnumValue3)]
        public void DeserializeTest(string json, string expectedRaw, TestEnum expected)
        {
            var obj = JsonConvert.DeserializeObject<JsonObject>(json);
            Assert.Equal(expectedRaw, obj.Enum.RawValue);
            Assert.Equal(expected, obj.Enum.Value);
        }

        [Fact]
        public void IsUnknownTest()
        {
            var wrapper = new ApiEnum<TestEnum>(TestEnum.EnumValue1, "SomeRandomValue");
            Assert.True(wrapper.IsUnknown);

            wrapper = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.False(wrapper.IsUnknown);
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
        public void ImplicitConversionToStringTest()
        {
            var expected = "SomeRawEnumValue";
            string actual = new ApiEnum<TestEnum>(TestEnum.EnumValue2, expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var item = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.True(item.Equals(item));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var item = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.False(item.Equals(item2));
            Assert.False(item.Equals(new object()));
            Assert.False(item.Equals(null));
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var item = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            Assert.Equal(item.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var item = new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString());
            var item2 = new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString());
            Assert.NotEqual(item.GetHashCode(), item2.GetHashCode());
        }

        #region ArgumentNullException tests

        [Fact]
        public void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNull(
                () => new ApiEnum<Enum>(TestEnum.EnumValue1),
                new[] { true });
            AssertArguments.ThrowsWhenNull(
                () => new ApiEnum<Enum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()),
                new[] { true, false });
        }

        #endregion
    }
}
