using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Json.Newtonsoft.Parsing.JsonTokenUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="float"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="float"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <c>0</c>.</returns>
    public static float GetFloat(this JArray? array, int index) {
        return TryParseFloat(GetToken(array, index), out float result) ? result : (float) 0;
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="float"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float? GetFloat(this JArray? array, int index, float fallback) {
        return TryParseFloat(GetToken(array, index), out float result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="float"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this JArray? array, int index) {
        return TryParseFloat(GetToken(array, index), out float result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="float"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <c>0</c>.</returns>
    public static float GetFloatByPath(this JArray? array, string path) {
        return ParseFloat(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="float"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float GetFloatByPath(this JArray? array, string path, float fallback) {
        return ParseFloat(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="float"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="float"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="float"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatByPathOrNull(this JArray? array, string path) {
        return ParseFloatOrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="float"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="float"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetFloat(this JArray? array, int index, out float result) {
        return TryParseFloat(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="float"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="float"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetFloat(this JArray? array, int index, [NotNullWhen(true)] out float? result) {
        return TryParseFloat(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="float"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="float"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetFloatByPath(this JArray? array, string path, out float result) {
        return TryParseFloat(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="float"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="float"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetFloatByPath(this JArray? array, string path, [NotNullWhen(true)] out float? result) {
        return TryParseFloat(array?.SelectToken(path), out result);
    }

}