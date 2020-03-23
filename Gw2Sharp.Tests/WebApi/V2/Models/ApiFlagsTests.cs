using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Models
{
    public class ApiFlagsTests
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
            public ApiFlags<TestEnum> Flags { get; set; } = default!;
        }

        [Fact]
        public void ConstructorTest()
        {
            var flags1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2) });
            var flags2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2), new ApiEnum<TestEnum>(TestEnum.EnumValue3) });

            Assert.Equal(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2) }, flags1.List);
            Assert.Equal(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2), new ApiEnum<TestEnum>(TestEnum.EnumValue3) }, flags2.List);
        }

#nullable disable
        public static IEnumerable<object[]> DeserializeTestData => new[]
        {
            new object[] { "{\"Flags\":[\"EnumValue2\"]}", new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2) } },
            new object[] { "{\"Flags\":[\"EnumValue2\",\"EnumValue3\"]}", new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2), new ApiEnum<TestEnum>(TestEnum.EnumValue3) } },
            new object[] { "{\"Flags\":[\"\"]}", new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue3, string.Empty) } },
            new object[] { "{\"Flags\":[null]}", new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue3, null) } },
            new object[] { "{\"Flags\":[]}", new ApiEnum<TestEnum>[0] },
            new object[] { "{\"Flags\":null}", null },
            new object[] { "{}", null },
        };
#nullable enable

        [Theory]
        [MemberData(nameof(DeserializeTestData))]
        public void DeserializeTest(string json, ApiEnum<TestEnum>[] expected)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ApiFlagsConverter());
            var obj = JsonSerializer.Deserialize<JsonObject>(json, options);

            if (expected == null)
                Assert.Null(obj.Flags);
            else
                Assert.Equal(expected, obj.Flags.List);
        }

        [Fact]
        public void HasUnknownTest()
        {
            var flags = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, "SomeRandomValue") });
            Assert.True(flags.HasUnknowns);
            Assert.Equal(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, "SomeRandomValue") }, flags.UnknownList);

            flags = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            Assert.False(flags.HasUnknowns);
            Assert.Empty(flags.UnknownList);

            flags = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, "enumValue1") });
            Assert.False(flags.HasUnknowns);
            Assert.Empty(flags.UnknownList);

            flags = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, "enum_value_1") });
            Assert.True(flags.HasUnknowns);
            Assert.Equal(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, "enum_value_1") }, flags.UnknownList);
        }

        [Fact]
        public void ImplicitConversionFromListTest()
        {
            var expectedArray = new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) };
            var expected = new ApiFlags<TestEnum>(expectedArray);
            ApiFlags<TestEnum> actual = expectedArray;
            Assert.Equal(expected, actual);

            actual = new List<ApiEnum<TestEnum>>(expectedArray);
            Assert.Equal(expected, actual);

            actual = new Collection<ApiEnum<TestEnum>>(expectedArray);
            Assert.Equal(expected, actual);

            actual = new HashSet<ApiEnum<TestEnum>>(expectedArray);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ImplicitConversionToListTest()
        {
            var expected = new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2) };
            ApiEnum<TestEnum>[] actualArray = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) });
            Assert.Equal(expected, actualArray);

            List<ApiEnum<TestEnum>> actualList = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) });
            Assert.Equal(expected, actualList);
        }

        [Fact]
        public void EqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            Assert.True(item1.Equals(item2));
        }

        [Fact]
        public void NotEqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString()) });
            var item3 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) });
            Assert.False(item1.Equals(item2));
            Assert.False(item1.Equals(item3));
            Assert.False(item2.Equals(item3));
            Assert.False(item1.Equals(new object()));
            Assert.False(item1.Equals(null!));
        }

        [Fact]
        public void HashCodeEqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            Assert.Equal(item1.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void HashCodeNotEqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString()) });
            var item3 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) });
            Assert.NotEqual(item1.GetHashCode(), item2.GetHashCode());
            Assert.NotEqual(item2.GetHashCode(), item3.GetHashCode());
            Assert.NotEqual(item1.GetHashCode(), item3.GetHashCode());
        }

        [Fact]
        public void OperatorEqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            Assert.True(item1 == item2);
        }

        [Fact]
        public void OperatorNotEqualsTest()
        {
            var item1 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue1.ToString()) });
            var item2 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1, TestEnum.EnumValue2.ToString()) });
            var item3 = new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue2, TestEnum.EnumValue2.ToString()) });
            Assert.True(item1 != item2);
            Assert.True(item1 != item3);
            Assert.True(item2 != item3);
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
            Assert.True(item1 != new object());
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            Assert.True(item1 != null!);
        }

        #region ArgumentNullException tests

        [Fact]
        public void ArgumentNullConstructorTest()
        {
            AssertArguments.ThrowsWhenNull(
                () => new ApiFlags<TestEnum>(new[] { new ApiEnum<TestEnum>(TestEnum.EnumValue1) }),
                new[] { true });
        }

        #endregion
    }
}
