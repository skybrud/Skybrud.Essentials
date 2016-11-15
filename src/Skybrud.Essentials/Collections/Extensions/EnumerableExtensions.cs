using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Collections.Extensions {

    /// <summary>
    /// Static class with extensions methods for instances of <code>IEnumerable</code>.
    /// </summary>
    public static class EnumerableExtensions {

        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> func, bool reverse) {
            return reverse ? collection.OrderByDescending(func) : collection.OrderBy(func);
        }

        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> func, SortOrder order) {
            return order == SortOrder.Descending ? collection.OrderByDescending(func) : collection.OrderBy(func);
        }

    }

}