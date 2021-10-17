using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        /// <summary>
        /// Casts the elements of an <see cref="IEnumerable"/> to the specified <paramref name="targetType"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> that contains the elements to be cast to <paramref name="targetType"/>.</param>
        /// <param name="targetType"></param>
        /// <returns>An <see cref="IEnumerable"/> that contains each element of the source sequence cast to the specified type.</returns>
        /// <remarks>The <see cref="Enumerable.Cast{TResult}"/> method requires developers to know the target type at compile time. Using the non-generic <see cref="Cast"/> method instead, the target type can be specified at runtime.</remarks>
        public static IEnumerable Cast(this IEnumerable source, Type targetType) {
            return (IEnumerable) typeof(Enumerable)
                .GetTypeInfo()
                .GetDeclaredMethod("Cast")
                .MakeGenericMethod(targetType)
                .Invoke(null, new object[] { source });
        }

        /// <summary>
        /// Creates an <see cref="IList"/> from an <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/> to create an <see cref="IList"/> from.</param>
        /// <param name="targetType">The type of the elements of <paramref name="source"/>.</param>
        /// <returns>An <see cref="IList"/> that contains elements from the input sequence.</returns>
        public static IList ToList(this IEnumerable source, Type targetType) {
            return (IList) typeof(Enumerable)
                .GetTypeInfo()
                .GetDeclaredMethod("ToList")
                .MakeGenericMethod(targetType)
                .Invoke(null, new object[] { source });
        }

        /// <summary>
        /// Creates an array from a <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="source">An <see cref="IEnumerable"/> to create an array from.</param>
        /// <param name="targetType">The type of the elements of <paramref name="source"/>.</param>
        /// <returns>An array that contains the elements from the input sequence.</returns>
        public static Array ToArray(this IEnumerable source, Type targetType) {
            return (Array) typeof(Enumerable)
                .GetTypeInfo()
                .GetDeclaredMethod("ToArray")
                .MakeGenericMethod(targetType)
                .Invoke(null, new object[] { source });
        }

        /// <summary>
        /// Creates a <see cref="HashSet{TResult}"/> from an <see cref="IEnumerable{T}"/> according to specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="HashSet{TResult}"/> from.</param>
        /// <param name="selector">A function to extract a key from each element.</param>
        /// <returns>A <see cref="HashSet{TResult}"/> that contains values of type <typeparamref name="TResult"/> selected from the input sequence.</returns>
        public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            return new HashSet<TResult>(source.Select(selector));
        }

        /// <summary>
        /// Creates a <see cref="HashSet{TResult}"/> from an <see cref="IEnumerable{T}"/> according to specified selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="HashSet{TResult}"/> from.</param>
        /// <param name="selector">A function to extract a key from each element.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or null to use the default <see cref="EqualityComparer{T}"/> implementation for the set type.</param>
        /// <returns>A <see cref="HashSet{TResult}"/> that contains values of type <typeparamref name="TResult"/> selected from the input sequence.</returns>
        public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, IEqualityComparer<TResult> comparer) {
            return new HashSet<TResult>(source.Select(selector), comparer);
        }

        /// <summary>
        /// Returns the reverse/opposite sort order of <paramref name="order"/>.
        /// </summary>
        /// <param name="order">The sort order.</param>
        /// <returns>An instance of <see cref="SortOrder"/>.</returns>
        public static SortOrder GetReverse(this SortOrder order) {
            return order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        }

    }

}