using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for implementing a list of API v2 objects.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public interface IApiV2ObjectList<out T> : IReadOnlyList<T>, IApiV2Object
    {
    }
}
