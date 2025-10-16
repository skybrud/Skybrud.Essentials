using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="long"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <c>0</c>.</returns>
    public static long GetInt64(this JArray? array, int index) {
        return JsonTokenUtils.TryParseInt64(JsonTokenUtils.GetToken(array, index), out long result) ? result : 0;
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="long"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static long? GetInt64(this JArray? array, int index, long fallback) {
        return JsonTokenUtils.TryParseInt64(JsonTokenUtils.GetToken(array, index), out long result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="long"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this JArray? array, int index) {
        return JsonTokenUtils.TryParseInt64(JsonTokenUtils.GetToken(array, index), out long result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="long"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <c>0</c>.</returns>
    public static long GetInt64ByPath(this JArray? array, string path) {
        return JsonTokenUtils.ParseInt64(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="long"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static long GetInt64ByPath(this JArray? array, string path, long fallback) {
        return JsonTokenUtils.ParseInt64(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="long"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="long"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64ByPathOrNull(this JArray? array, string path) {
        return JsonTokenUtils.ParseInt64OrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="long"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetInt64(this JArray? array, int index, out long result) {
        return JsonTokenUtils.TryParseInt64(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="long"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetInt64(this JArray? array, int index, [NotNullWhen(true)] out long? result) {
        return JsonTokenUtils.TryParseInt64(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="long"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="long"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetInt64ByPath(this JArray? array, string path, out long result) {
        return JsonTokenUtils.TryParseInt64(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="long"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="long"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetInt64ByPath(this JArray? array, string path, [NotNullWhen(true)] out long? result) {
        return JsonTokenUtils.TryParseInt64(array?.SelectToken(path), out result);
    }

}