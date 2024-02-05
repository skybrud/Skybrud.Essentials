using System.Collections.Generic;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlyCollection{T}"/>.
/// </summary>
public static class ReadOnlyCollection {

    /// <summary>
    /// Returns an empty instance of <see cref="IReadOnlyCollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the collection.</typeparam>
    /// <returns>An instance of <see cref="IReadOnlyCollection{T}"/>.</returns>
    public static IReadOnlyCollection<T> Empty<T>() {
        return ArrayUtils.Empty<T>();
    }

}