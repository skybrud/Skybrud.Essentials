using System.Collections.Generic;

namespace Skybrud.Essentials.Collections.Extensions;

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

}