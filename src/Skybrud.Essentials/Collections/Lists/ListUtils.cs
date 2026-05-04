using System.Collections.Generic;

// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery

namespace Skybrud.Essentials.Collections.Lists;

/// <summary>
/// Utility class with methods for working with <see cref="List{T}"/> and <see cref="IReadOnlyList{T}"/>.
/// </summary>
public static class ListUtils {

    /// <summary>
    /// Returns a new enumerable containing the items from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements of <paramref name="first"/>
    /// followed by the elements of <paramref name="second"/>.
    /// </returns>
    public static List<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second) {
        List<T> temp = [];
        if (first is not null) temp.AddRange(first);
        if (second is not null) temp.AddRange(second);
        return temp;
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
    /// An <see cref="IEnumerable{T}"/> that contains the elements of <paramref name="first"/>
    /// followed by the elements of <paramref name="second"/>.
    /// </returns>
    public static List<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third) {
        List<T> temp = [];
        if (first is not null) temp.AddRange(first);
        if (second is not null) temp.AddRange(second);
        if (third is not null) temp.AddRange(third);
        return temp;
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
    /// An <see cref="IEnumerable{T}"/> that contains the elements of <paramref name="first"/>
    /// followed by the elements of <paramref name="second"/>.
    /// </returns>
    public static List<T> Concat<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third, IEnumerable<T>? fourth) {
        List<T> temp = [];
        if (first is not null) temp.AddRange(first);
        if (second is not null) temp.AddRange(second);
        if (third is not null) temp.AddRange(third);
        if (fourth is not null) temp.AddRange(fourth);
        return temp;
    }

    /// <summary>
    /// Concatenates multiple sequences into a single list, skipping any <see langword="null"/> collections.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the input sequences.
    /// </typeparam>
    /// <param name="collections">
    /// An array of sequences to concatenate. Any <see langword="null"/> sequence is ignored.
    /// </param>
    /// <returns>
    /// A <see cref="List{T}"/> that contains the concatenated elements of all
    /// non-<see langword="null"/> input sequences, in the order they are provided.
    /// </returns>
    /// <remarks>
    /// This method safely handles <see langword="null"/> input collections by excluding them
    /// from the result instead of throwing an exception.
    /// </remarks>
    public static List<T> Concat<T>(params IEnumerable<T>?[] collections) {
        List<T> result = [];
        foreach (IEnumerable<T>? collection in collections) {
            if (collection is not null) result.AddRange(collection);
        }
        return result;
    }

    /// <summary>
    /// Returns a new list that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from
    /// <paramref name="first"/> and <paramref name="second"/>.
    /// </returns>
    public static List<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second) {

        HashSet<T> set = [];
        List<T> result = [];

        if (first is not null) {
            foreach (T item in first) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (second is not null) {
            foreach (T item in second) {
                if (set.Add(item)) result.Add(item);
            }
        }

        return result;

    }

    /// <summary>
    /// Returns a new list that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from
    /// <paramref name="first"/> and <paramref name="second"/>.
    /// </returns>
    public static List<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third) {

        HashSet<T> set = [];
        List<T> result = [];

        if (first is not null) {
            foreach (T item in first) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (second is not null) {
            foreach (T item in second) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (third is not null) {
            foreach (T item in third) {
                if (set.Add(item)) result.Add(item);
            }
        }

        return result;

    }

    /// <summary>
    /// Returns a new list that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="first">The first sequence.</param>
    /// <param name="second">The second sequence.</param>
    /// <param name="third">The third sequence.</param>
    /// <param name="fourth">The fourth sequence.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the distinct elements from
    /// <paramref name="first"/> and <paramref name="second"/>.
    /// </returns>
    public static List<T> Union<T>(IEnumerable<T>? first, IEnumerable<T>? second, IEnumerable<T>? third, IEnumerable<T>? fourth) {

        HashSet<T> set = [];
        List<T> result = [];

        if (first is not null) {
            foreach (T item in first) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (second is not null) {
            foreach (T item in second) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (third is not null) {
            foreach (T item in third) {
                if (set.Add(item)) result.Add(item);
            }
        }

        if (fourth is not null) {
            foreach (T item in fourth) {
                if (set.Add(item)) result.Add(item);
            }
        }

        return result;

    }

    /// <summary>
    /// Returns a new list that contains the distinct elements from the specified enumerables.
    /// If any of the enumerables is <see langword="null"/>, it is treated as an empty enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequences.</typeparam>
    /// <param name="collections">
    /// An array of sequences whose distinct elements should be combined into a single list.
    /// Any <see langword="null"/> sequence is ignored.
    /// </param>
    /// <returns>
    /// A <see cref="List{T}"/> that contains the distinct elements from all
    /// non-<see langword="null"/> input sequences, in the order they are encountered.
    /// </returns>
    /// <remarks>
    /// This method safely handles <see langword="null"/> input collections by excluding them
    /// from the result instead of throwing an exception.
    /// </remarks>
    public static List<T> Union<T>(params IEnumerable<T>?[] collections) {
        HashSet<T> set = [];
        List<T> list = [];
        foreach (IEnumerable<T>? collection in collections) {
            if (collection is null) continue;
            foreach (T item in collection) {
                if (set.Add(item)) list.Add(item);
            }
        }
        return list;
    }

}