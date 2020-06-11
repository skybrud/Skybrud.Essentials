using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Collections.Extensions {

    /// <summary>
    /// Static class with extensions methods for instances of <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions {

        /// <summary>
        /// Orders <paramref name="collection"/> in descending order if <paramref name="reverse"/> is
        /// <c>true</c>, otherwise in ascending order.
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

        /// <summary>
        /// Sorts the elements of <paramref name="source"/> in descending order if <paramref name="reverse"/> is
        /// <c>true</c>, otherwise in ascending order.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">The collection to be sorted.</param>
        /// <param name="func">The callback function used for sorting the items.</param>
        /// <returns>An instanced of <see cref="IOrderedEnumerable{T}"/>.</returns>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare the keys.</param>
        /// <param name="reverse">Whether <paramref name="source"/> should be sorted in descending order.</param>
        /// <returns>An instanced of <see cref="IOrderedEnumerable{T}"/>.</returns>
        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> func, IComparer<TKey> comparer, bool reverse) {
            return reverse ? source.OrderByDescending(func, comparer) : source.OrderBy(func, comparer);
        }

        /// <summary>
        /// Orders <paramref name="source"/> in descending order if <paramref name="order"/> is
        /// <see cref="SortOrder.Descending"/>, otherwise in ascending order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare the keys.</param>
        /// <param name="order">The order by which the collection should be sorted.</param>
        /// <returns>An instanced of <see cref="IOrderedEnumerable{T}"/>.</returns>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, SortOrder order) {
            return order == SortOrder.Descending ? source.OrderByDescending(keySelector, comparer) : source.OrderBy(keySelector, comparer);
        }

    }

}