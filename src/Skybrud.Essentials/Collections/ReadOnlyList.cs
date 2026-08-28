using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlyList{T}"/>.
/// </summary>
public static class ReadOnlyList {

    /// <summary>
    /// Returns an empty read-only list of the specified <paramref name="itemType"/>.
    /// </summary>
    /// <param name="itemType">The type of the items.</param>
    /// <returns>A read-only list of <paramref name="itemType"/>.</returns>
    public static IEnumerable Empty(Type itemType) {
        return (IEnumerable) typeof(ReadOnlyList)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(Empty))
            .First(x => x.GetParameters().Length == 0)
            .MakeGenericMethod(itemType)
            .Invoke(null, null)!;
    }

    /// <summary>
    /// Returns an empty instance of <see cref="IReadOnlyList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the list.</typeparam>
    /// <returns>An instance of <see cref="IReadOnlyList{T}"/>.</returns>
    public static IReadOnlyList<T> Empty<T>() {
        return [];
    }

}