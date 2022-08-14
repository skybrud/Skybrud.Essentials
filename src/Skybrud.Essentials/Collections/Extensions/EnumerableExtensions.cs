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
        /// Returns distinct elements from a sequence according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
        /// <param name="source">The sequence to remove duplicate elements from.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> that contains distinct elements from the source sequence.</returns>
        /// <see>
        ///     <cref>https://github.com/dotnet/runtime/blob/v6.0.4/src/libraries/System.Linq/src/System/Linq/Distinct.cs#L34</cref>
        /// </see>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            return DistinctBy(source, keySelector, null);
        }

        /// <summary>
        /// Returns distinct elements from a sequence according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of key to distinguish elements by.</typeparam>
        /// <param name="source">The sequence to remove duplicate elements from.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{TKey}" /> to compare keys.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> that contains distinct elements from the source sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
        /// <see>
        ///     <cref>https://github.com/dotnet/runtime/blob/v6.0.4/src/libraries/System.Linq/src/System/Linq/Distinct.cs#L48</cref>
        /// </see>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (keySelector is null) throw new ArgumentNullException(nameof(keySelector));
            return DistinctByIterator(source, keySelector, comparer);
        }

        /// <see>
        ///     <cref>https://github.com/dotnet/runtime/blob/v6.0.4/src/libraries/System.Linq/src/System/Linq/Distinct.cs#L62</cref>
        /// </see>
        private static IEnumerable<TSource> DistinctByIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) {

            using IEnumerator<TSource> enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext()) yield break;

            HashSet<TKey> set = new(comparer);

            do {
                TSource element = enumerator.Current;
                if (set.Add(keySelector(element))) {
                    yield return element;
                }
            } while (enumerator.MoveNext());

        }

        /// <summary>
        /// Divides and returns <paramref name="source"/> into individual groups, where each group having a maximum size of <paramref name="groupSize"/>.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">The input collection to be grouped.</param>
        /// <param name="groupSize">The maximum size of each group.</param>
        /// <returns>A collection of indifivial <see cref="IEnumerable{TSource}"/> instances representing each group.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="groupSize"/> is not greater than <c>0</c>.</exception>
        /// <see>
        ///     <cref>https://github.com/umbraco/Umbraco-CMS/blob/v9/contrib/src/Umbraco.Core/Extensions/EnumerableExtensions.cs#L42</cref>
        /// </see>
        public static IEnumerable<IEnumerable<TSource>> InGroupsOf<TSource>(this IEnumerable<TSource> source, int groupSize) {

            if (source == null) throw new ArgumentNullException(nameof(source));
            if (groupSize <= 0) throw new ArgumentException("Must be greater than zero.", nameof(groupSize));

            TSource[] temp = null;
            var count = 0;

            foreach (var item in source) {
                if (temp == null) temp = new TSource[groupSize];
                temp[count++] = item;
                if (count != groupSize) continue;
                yield return temp;
                temp = null;
                count = 0;
            }

            if (temp != null && count > 0) yield return temp.Take(count);

        }

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
        /// Filters a sequence of values to ignore those which are null.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">The collection to be filtered.</param>
        /// <returns>An instanced of <see cref="IEnumerable{TSource}"/> without any null values..</returns>
        /// <see>
        ///     <cref>https://github.com/umbraco/Umbraco-CMS/blob/v9/contrib/src/Umbraco.Core/Extensions/EnumerableExtensions.cs#L226</cref>
        /// </see>
        public static IEnumerable<TSource> WhereNotNull<TSource>(this IEnumerable<TSource> source) where TSource : class {
            return source.Where(x => x != null);
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

        /// <summary>
        /// Deconstructs the specified <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The tpye of the items of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="first">When this method returns, holds the first item if the collection has at least one item;
        /// otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="second">When this method returns, holds the second item if the collection has at least two
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        public static void Deconstruct<T>(this IEnumerable<T> collection, out T first, out T second) {

            first = default;
            second = default;

            int i = 0;

            foreach (T item in collection) {

                switch (i) {
                    case 0:
                        first = item;
                        break;
                    case 1:
                        second = item;
                        break;
                    default:
                        return;
                }

                i++;

            }

        }

        /// <summary>
        /// Deconstructs the specified <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The tpye of the items of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="first">When this method returns, holds the first item if the collection has at least one item;
        /// otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="second">When this method returns, holds the second item if the collection has at least two
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="third">When this method returns, holds the third item if the collection has at least three
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        public static void Deconstruct<T>(this IEnumerable<T> collection, out T first, out T second, out T third) {

            first = default;
            second = default;
            third = default;

            int i = 0;

            foreach (T item in collection) {
                switch (i++) {
                    case 0: first = item; break;
                    case 1: second = item; break;
                    case 2: third = item; break;
                    default: return;
                }
            }

        }

        /// <summary>
        /// Deconstructs the specified <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The tpye of the items of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="first">When this method returns, holds the first item if the collection has at least one item;
        /// otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="second">When this method returns, holds the second item if the collection has at least two
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="third">When this method returns, holds the third item if the collection has at least three
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        /// <param name="fourth">When this method returns, holds the fourth item if the collection has at least four
        /// items; otherwise, the default value of <typeparamref name="T"/>.</param>
        public static void Deconstruct<T>(this IEnumerable<T> collection, out T first, out T second, out T third, out T fourth) {

            first = default;
            second = default;
            third = default;
            fourth = default;

            int i = 0;

            foreach (T item in collection) {
                switch (i++) {
                    case 0: first = item; break;
                    case 1: second = item; break;
                    case 2: third = item; break;
                    case 3: fourth = item; break;
                    default: return;
                }
            }

        }

        /// <summary>
        /// Returns a random element from the specified <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A random item of type <typeparamref name="TSource"/> from <paramref name="collection"/> if not empty; otherwise, the default value of <typeparamref name="TSource"/>.</returns>
        /// <remarks>
        ///     <para>The implementation of this method uses <see cref="Guid.NewGuid"/> for sorting the items in a random order. When testing various implementions, this seems to be the most random.</para>
        /// </remarks>
        public static TSource RandomOrDefault<TSource>(this IEnumerable<TSource> collection) {
            return collection.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
        }

        /// <summary>
        /// Returns a new version of <paramref name="collection"/> whose elements are sorted in a random order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A new <see cref="IOrderedEnumerable{T}"/> whose elements are sorted in a random order.</returns>
        /// <remarks>
        ///     <para>The implementation of this method uses <see cref="Guid.NewGuid"/> for sorting the items in a random order. When testing various implementions, this seems to be the most random.</para>
        /// </remarks>
        public static IOrderedEnumerable<TSource> OrderByRandom<TSource>(this IEnumerable<TSource> collection) {
            return collection.OrderBy(_ => Guid.NewGuid());
        }

        /// <summary>
        /// Returns a new version of <paramref name="collection"/> whose elements are sorted in a random order.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A new <see cref="IOrderedEnumerable{T}"/> whose elements are sorted in a random order.</returns>
        /// <remarks>
        ///     <para>The implementation of this method uses <see cref="Guid.NewGuid"/> for sorting the items in a random order. When testing various implementions, this seems to be the most random.</para>
        /// </remarks>
        public static IOrderedEnumerable<TSource> Randomize<TSource>(this IEnumerable<TSource> collection) {
            return collection.OrderBy(_ => Guid.NewGuid());
        }

    }

}