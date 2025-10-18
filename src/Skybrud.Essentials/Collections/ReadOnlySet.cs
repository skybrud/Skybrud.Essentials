#if NET5_0_OR_GREATER

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlySet{T}"/>.
/// </summary>
public static class ReadOnlySet {

    /// <summary>
    /// Returns an empty read-only set of the specified <paramref name="itemType"/>.
    /// </summary>
    /// <param name="itemType">The type of the items.</param>
    /// <returns>A read-only set of <paramref name="itemType"/>.</returns>
    public static IEnumerable Empty(Type itemType) {
        return (IEnumerable) typeof(ReadOnlySet)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(Empty))
            .First(x => x.GetParameters().Length == 0)
            .MakeGenericMethod(itemType)
            .Invoke(null, null)!;
    }

    /// <summary>
    /// Returns an empty instance of <see cref="IReadOnlySet{T}"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the list.</typeparam>
    /// <returns>An instance of <see cref="IReadOnlySet{T}"/>.</returns>
    public static IReadOnlySet<T> Empty<T>() {
        return EmptyHashSet<T>.Value;
    }

    private static class EmptyHashSet<T> {

        internal static readonly IReadOnlySet<T> Value = ImmutableHashSet.Create<T>();

    }

}

#endif