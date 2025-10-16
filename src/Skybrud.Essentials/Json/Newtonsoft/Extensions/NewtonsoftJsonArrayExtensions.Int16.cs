using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Json.Newtonsoft.Parsing.JsonTokenUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="short"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <c>0</c>.</returns>
    public static short GetInt16(this JArray? array, int index) {
        return TryParseInt16(GetToken(array, index), out short result) ? result : (short) 0;
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="short"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static short? GetInt16(this JArray? array, int index, short fallback) {
        return TryParseInt16(GetToken(array, index), out short result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="short"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static short? GetInt16OrNull(this JArray? array, int index) {
        return TryParseInt16(GetToken(array, index), out short result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="short"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <c>0</c>.</returns>
    public static short GetInt16ByPath(this JArray? array, string path) {
        return ParseInt16(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="short"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static short GetInt16ByPath(this JArray? array, string path, short fallback) {
        return ParseInt16(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="short"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static short? GetInt16ByPathOrNull(this JArray? array, string path) {
        return ParseInt16OrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="short"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="short"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetInt16(this JArray? array, int index, out short result) {
        return TryParseInt16(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="short"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="short"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetInt16(this JArray? array, int index, [NotNullWhen(true)] out short? result) {
        return TryParseInt16(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="short"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="short"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetInt16ByPath(this JArray? array, string path, out short result) {
        return TryParseInt16(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="short"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="short"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetInt16ByPath(this JArray? array, string path, [NotNullWhen(true)] out short? result) {
        return TryParseInt16(array?.SelectToken(path), out result);
    }

}