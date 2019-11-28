using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nestor
{
    public static class EnumerableExtensions
    {
        public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
        {
            return Task.WhenAll(source.Select(action));
        }
    }
}