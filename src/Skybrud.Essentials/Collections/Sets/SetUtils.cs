using System.Collections.Generic;

namespace Skybrud.Essentials.Collections.Sets;

/// <summary>
/// Static class with utility methods for working with <see cref="ISet{T}"/>.
/// </summary>
public class SetUtils {

    /// <summary>
    /// Returns a new set that is the union of the specified collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sets.</typeparam>
    /// <param name="one">The first collection to union. May be <see langword="null"/>.</param>
    /// <param name="two">The second collection to union. May be <see langword="null"/>.</param>
    /// <returns>A set containing the union of the specified collections.</returns>
    public static ISet<T> Union<T>(IEnumerable<T>? one, IEnumerable<T>? two) {
        HashSet<T> temp = [];
        if (one is not null) temp.UnionWith(one);
        if (two is not null) temp.UnionWith(two);
        return temp;
    }

    /// <summary>
    /// Returns a new set that is the union of the specified collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sets.</typeparam>
    /// <param name="one">The first collection to union. May be <see langword="null"/>.</param>
    /// <param name="two">The second collection to union. May be <see langword="null"/>.</param>
    /// <param name="three">The third collection to union. May be <see langword="null"/>.</param>
    /// <returns>A set containing the union of the specified collections.</returns>
    public static ISet<T> Union<T>(IEnumerable<T>? one, IEnumerable<T>? two, IEnumerable<T>? three) {
        HashSet<T> temp = [];
        if (one is not null) temp.UnionWith(one);
        if (two is not null) temp.UnionWith(two);
        if (three is not null) temp.UnionWith(three);
        return temp;
    }

    /// <summary>
    /// Returns a new set that is the union of the specified collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sets.</typeparam>
    /// <param name="one">The first collection to union. May be <see langword="null"/>.</param>
    /// <param name="two">The second collection to union. May be <see langword="null"/>.</param>
    /// <param name="three">The third collection to union. May be <see langword="null"/>.</param>
    /// <param name="four">The fourth collection to union. May be <see langword="null"/>.</param>
    /// <returns>A set containing the union of the specified collections.</returns>
    public static ISet<T> Union<T>(IEnumerable<T>? one, IEnumerable<T>? two, IEnumerable<T>? three, IEnumerable<T>? four) {
        HashSet<T> temp = [];
        if (one is not null) temp.UnionWith(one);
        if (two is not null) temp.UnionWith(two);
        if (three is not null) temp.UnionWith(three);
        if (four is not null) temp.UnionWith(four);
        return temp;
    }

}