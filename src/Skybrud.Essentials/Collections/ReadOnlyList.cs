using System.Collections.Generic;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlyList{T}"/>.
/// </summary>
public static class ReadOnlyList {

    /// <summary>
    /// Returns an empty instance of <see cref="IReadOnlyList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the list.</typeparam>
    /// <returns>An instance of <see cref="IReadOnlyList{T}"/>.</returns>
    public static IReadOnlyList<T> Empty<T>() {
        return ArrayUtils.Empty<T>();
    }

}