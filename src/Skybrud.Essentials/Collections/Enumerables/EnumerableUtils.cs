using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Collections.Enumerables;

/// <summary>
/// Static class with utility methods for working with <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableUtils {

    /// <summary>
    /// Returns a new enumerable containing the items from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements of the specified enumerable.
    /// </returns>
    public static IEnumerable<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second) {
        return (first ?? []).Concat(second ?? []);
    }

    /// <summary>
    /// Returns a new enumerable containing the items from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements of the specified enumerable.
    /// </returns>
    public static IEnumerable<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third) {
        return (first ?? []).Concat(second ?? []).Concat(third ?? []);
    }

    /// <summary>
    /// Returns a new enumerable containing the items from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <param name="fourth">The fourth sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements of the specified enumerable.
    /// </returns>
    public static IEnumerable<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third, IEnumerable<T>? fourth) {
        return (first ?? []).Concat(second ?? []).Concat(third ?? []).Concat(fourth ?? []);
    }

    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the concatenated elements of all non-<see langword="null"/> input
    /// sequences, in the order they are provided.
    /// </returns>
    /// <remarks>
    /// This method safely handles <see langword="null"/> input collections by excluding them from the result instead
    /// of throwing an exception.
    /// </remarks>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements of the specified enumerable.
    /// </returns>
    public static IEnumerable<T> Concat<T>(params IEnumerable<T>?[] collections) {
        foreach (IEnumerable<T>? collection in collections) {
            if (collection is null) continue;
            foreach (T item in collection) yield return item;
        }
    }

    /// <summary>
    /// Returns a new enumerable that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from the specified enumerables.
    /// </returns>
    public static IEnumerable<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second) {
        return (first ?? []).Union(second ?? []);
    }

    /// <summary>
    /// Returns a new enumerable that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from the specified enumerables.
    /// </returns>
    public static IEnumerable<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third) {
        return (first ?? []).Union(second ?? []).Union(third ?? []);
    }

    /// <summary>
    /// Returns a new enumerable that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <param name="fourth">The fourth sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from the specified enumerables.
    /// </returns>
    public static IEnumerable<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third, IEnumerable<T>? fourth) {
        return (first ?? []).Union(second ?? []).Union(third ?? []).Union(fourth ?? []);
    }

    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from all
    /// non-<see langword="null"/> input sequences, in the order they are encountered.
    /// </returns>
    /// <remarks>
    /// This method safely handles <see langword="null"/> input collections by excluding them
    /// from the result instead of throwing an exception.
    /// </remarks>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from the specified enumerables.
    /// </returns>
    public static IEnumerable<T> Union<T>(IEqualityComparer<T>? comparer = null, params IEnumerable<T>?[] collections) {
        HashSet<T> seen = new(comparer);
        foreach (IEnumerable<T>? collection in collections) {
            if (collection is null) continue;
            foreach (T item in collection) {
                if (seen.Add(item)) yield return item;
            }
        }
    }

}