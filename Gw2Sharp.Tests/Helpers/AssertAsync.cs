using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Gw2Sharp.Tests.Helpers
{
    public static class AssertAsync
    {
        public static async Task All<T>(IEnumerable<Task<T>> tasks, Action<T> action)
        {
            Assert.All(await Task.WhenAll(tasks), action);
        }
    }
}
