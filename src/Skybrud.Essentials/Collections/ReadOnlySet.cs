#if NET5_0_OR_GREATER

using System.Collections.Generic;
using System.Collections.Immutable;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class for working with <see cref="IReadOnlySet{T}"/>.
/// </summary>
public static class ReadOnlySet {

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