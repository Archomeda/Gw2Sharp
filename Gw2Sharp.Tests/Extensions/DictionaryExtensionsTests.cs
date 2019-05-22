using System.Collections.Generic;
using Gw2Sharp.Extensions;
using Xunit;

namespace Gw2Sharp.Tests.Extensions
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void ShallowCopyTest()
        {
            var (str1, obj1) = ("obj1", new object());
            var (str2, obj2) = ("obj2", new object());
            var dict = new Dictionary<string, object>()
            {
                { str1, obj1 },
                { str2, obj2 }
            };
            var copyDict = dict.ShallowCopy();

            Assert.Same(obj1, copyDict[str1]);
            Assert.Same(obj2, copyDict[str2]);
        }

        [Fact]
        public void AddRangeTest()
        {
            var (str1, obj1) = ("obj1", new object());
            var (str2, obj2) = ("obj2", new object());
            var (str3, obj3) = ("obj3", new object());
            var dict = new Dictionary<string, object>()
            {
                { str1, obj1 }
            };
            dict.AddRange(new Dictionary<string, object>
            {
                { str2, obj2 },
                { str3, obj3 }
            });

            Assert.Contains(new KeyValuePair<string, object>(str2, obj2), dict);
            Assert.Contains(new KeyValuePair<string, object>(str3, obj3), dict);
        }

        [Fact]
        public void AsReadOnlyTest()
        {
            var (str1, obj1) = ("obj1", new object());
            var (str2, obj2) = ("obj2", new object());
            var dict = new Dictionary<string, object>()
            {
                { str1, obj1 },
                { str2, obj2 }
            };
            var readOnlyDict = dict.AsReadOnly();

            Assert.IsAssignableFrom<IReadOnlyDictionary<string, object>>(readOnlyDict);
        }
    }
}
