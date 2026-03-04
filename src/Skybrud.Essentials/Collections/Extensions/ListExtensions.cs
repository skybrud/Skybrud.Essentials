using System.Collections.Generic;

namespace Skybrud.Essentials.Collections.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="IReadOnlyList{T}"/>.
/// </summary>
public static class ListExtensions {

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into its first element.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first) {
        first = list.Count > 0 ? list[0] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to two elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to three elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="third">Receives the element at index 2, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b, c) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second, out T? third) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
        third = list.Count > 2 ? list[2] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to four elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="third">Receives the element at index 2, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fourth">Receives the element at index 3, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b, c, d) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second, out T? third, out T? fourth) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
        third = list.Count > 2 ? list[2] : default;
        fourth = list.Count > 3 ? list[3] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to five elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="third">Receives the element at index 2, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fourth">Receives the element at index 3, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fifth">Receives the element at index 4, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b, c, d, e) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second, out T? third, out T? fourth, out T? fifth) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
        third = list.Count > 2 ? list[2] : default;
        fourth = list.Count > 3 ? list[3] : default;
        fifth = list.Count > 4 ? list[4] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to six elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="third">Receives the element at index 2, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fourth">Receives the element at index 3, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fifth">Receives the element at index 4, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="sixth">Receives the element at index 5, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b, c, d, e, f) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second, out T? third, out T? fourth, out T? fifth, out T? sixth) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
        third = list.Count > 2 ? list[2] : default;
        fourth = list.Count > 3 ? list[3] : default;
        fifth = list.Count > 4 ? list[4] : default;
        sixth = list.Count > 5 ? list[5] : default;
    }

    /// <summary>
    /// Deconstructs an <see cref="IReadOnlyList{T}"/> into up to seven elements.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements contained in the list.</typeparam>
    /// <param name="list">The source list to deconstruct.</param>
    /// <param name="first">Receives the element at index 0, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="second">Receives the element at index 1, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="third">Receives the element at index 2, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fourth">Receives the element at index 3, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="fifth">Receives the element at index 4, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="sixth">Receives the element at index 5, or <c>default</c> if the list has fewer elements.</param>
    /// <param name="seventh">Receives the element at index 6, or <c>default</c> if the list has fewer elements.</param>
    /// <remarks>
    /// This method enables deconstruction syntax, for example:
    /// <code>
    /// var (a, b, c, d, e, f, g) = list;
    /// </code>
    /// </remarks>
    public static void Deconstruct<T>(this IReadOnlyList<T> list, out T? first, out T? second, out T? third, out T? fourth, out T? fifth, out T? sixth, out T? seventh) {
        first = list.Count > 0 ? list[0] : default;
        second = list.Count > 1 ? list[1] : default;
        third = list.Count > 2 ? list[2] : default;
        fourth = list.Count > 3 ? list[3] : default;
        fifth = list.Count > 4 ? list[4] : default;
        sixth = list.Count > 5 ? list[5] : default;
        seventh = list.Count > 6 ? list[6] : default;
    }

}