using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Core
{
    public static class EnumerableExtensions
    {
        public static void ForEachIndexed<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in enumerable)
            {
                action(item, i);
                i++;
            }
        }
    }
}
