using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlyCollection{T}"/>.
/// </summary>
public static class ReadOnlyCollection {

    /// <summary>
    /// Returns an empty read-only collection of the specified <paramref name="itemType"/>.
    /// </summary>
    /// <param name="itemType">The type of the items.</param>
    /// <returns>A read-only collection of <paramref name="itemType"/>.</returns>
    public static IEnumerable Empty(Type itemType) {
        return (IEnumerable) typeof(ReadOnlyCollection)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(Empty))
            .First(x => x.GetParameters().Length == 0)
            .MakeGenericMethod(itemType)
            .Invoke(null, null)!;
    }

    /// <summary>
    /// Returns an empty instance of <see cref="IReadOnlyCollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the collection.</typeparam>
    /// <returns>An instance of <see cref="IReadOnlyCollection{T}"/>.</returns>
    public static IReadOnlyCollection<T> Empty<T>() {
        return [];
    }

}