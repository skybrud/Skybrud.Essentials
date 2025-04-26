using System;
using System.Linq;
using System.Reflection;

namespace Skybrud.Essentials.Collections;

/// <summary>
/// Static class with various logic for working with arrays.
/// </summary>
public static class ArrayUtils {

    /// <summary>
    /// Returns an empty array of the specified <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type of the items in the array.</param>
    /// <returns>An array of <paramref name="type"/>.</returns>
    public static Array Empty(Type type) {
        return (Array) typeof(ArrayUtils)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(Empty))
            .First(x => x.GetParameters().Length == 0)
            .MakeGenericMethod(type)
            .Invoke(null, null)!;
    }

    /// <summary>
    /// Returns an empty array.
    /// </summary>
    /// <typeparam name="T">The type of the items in the array.</typeparam>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    /// <see>
    ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.array.empty?view=net-6.0</cref>
    /// </see>
    public static T[] Empty<T>() {
        return [];
    }

}