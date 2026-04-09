using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Collections.Sets.Extensions;

/// <summary>
/// Static class with extension methods for <see cref="ISet{T}"/>.
/// </summary>
public static class SetExtensions {

    /// <summary>
    /// Adds the elements of the specified collection to the end of the <see cref="ISet{T}"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="set">The set to which the elements of <paramref name="collection"/> should be added.</param>
    /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ISet{T}"/>. The collection itself cannot be null, but it can contain elements that are null, if type <typeparamref name="T"/> is a reference type.</param>
    public static void AddRange<T>(this ISet<T> set, IEnumerable<T> collection) {
        foreach (T item in collection) set.Add(item);
    }

    /// <summary>
    /// Attempts to add the specified item to the <see cref="ISet{T}"/>.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the <see cref="ISet{T}"/>.</typeparam>
    /// <param name="set">The target <see cref="ISet{T}"/>.</param>
    /// <param name="item">The item to add to the set.</param>
    /// <returns>
    /// <see langword="true"/> if the item was successfully added; <see langword="false"/> if the item already existed in the set.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> is <see langword="null"/>.</exception>
    public static bool TryAdd<T>(this ISet<T> set, T item) {
        if (set is null) throw new ArgumentNullException(nameof(set));
        return set.Add(item);
    }

    /// <summary>
    /// Attempts to add multiple items to the <see cref="ISet{T}"/>, skipping elements that already exist.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <see cref="ISet{T}"/>.</typeparam>
    /// <param name="set">The target <see cref="ISet{T}"/>.</param>
    /// <param name="items">The collection of items to add to the set.</param>
    /// <returns>The number of items that were successfully added to the set.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> or <paramref name="items"/> is <see langword="null"/>.</exception>
    public static int TryAddRange<T>(this ISet<T> set, IEnumerable<T> items) {
        if (set is null) throw new ArgumentNullException(nameof(set));
        if (items is null) throw new ArgumentNullException(nameof(items));
        int addedCount = 0;
        foreach (T item in items) {
            if (set.Add(item)) addedCount++;
        }
        return addedCount;
    }

}