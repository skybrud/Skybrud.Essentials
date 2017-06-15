using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Collections.Extensions {

    /// <summary>
    /// Static class with extensions methods for instances of <code>IEnumerable</code>.
    /// </summary>
    public static class EnumerableExtensions {

        /// <summary>
        /// Orders <paramref name="collection"/> in descending order if <paramref name="reverse"/> is
        /// <code>true</code>, otherwise in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="collection">The collection to be sorted.</param>
        /// <param name="func">The callback function used for sorting the items.</param>
        /// <param name="reverse">Whether <paramref name="collection"/> should be sorted in descending order.</param>
        /// <returns>An instanced of <see cref="IOrderedEnumerable{T}"/>.</returns>
        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> func, bool reverse) {
            return reverse ? collection.OrderByDescending(func) : collection.OrderBy(func);
        }

        /// <summary>
        /// Orders <paramref name="collection"/> in descending order if <paramref name="order"/> is
        /// <see cref="SortOrder.Descending"/>, otherwise in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="collection">The collection to be sorted.</param>
        /// <param name="func">The callback function used for sorting the items.</param>
        /// <param name="order">The order by which the collection should be sorted.</param>
        /// <returns>An instanced of <see cref="IOrderedEnumerable{T}"/>.</returns>
        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> func, SortOrder order) {
            return order == SortOrder.Descending ? collection.OrderByDescending(func) : collection.OrderBy(func);
        }

    }

}