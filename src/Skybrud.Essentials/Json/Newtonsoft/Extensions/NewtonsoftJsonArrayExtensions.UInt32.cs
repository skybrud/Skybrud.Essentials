using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <c>0</c>.</returns>
    public static uint GetUInt32(this JArray? array, int index) {
        return JsonTokenUtils.TryParseUInt32(JsonTokenUtils.GetToken(array, index), out uint result) ? result : 0;
    }

    /// <summary>
    /// Returns the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static uint? GetUInt32(this JArray? array, int index, uint fallback) {
        return JsonTokenUtils.TryParseUInt32(JsonTokenUtils.GetToken(array, index), out uint result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static uint? GetUInt32OrNull(this JArray? array, int index) {
        return JsonTokenUtils.TryParseUInt32(JsonTokenUtils.GetToken(array, index), out uint result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <c>0</c>.</returns>
    public static uint GetUInt32ByPath(this JArray? array, string path) {
        return JsonTokenUtils.ParseUInt32(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static uint GetUInt32ByPath(this JArray? array, string path, uint fallback) {
        return JsonTokenUtils.ParseUInt32(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="uint"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static uint? GetUInt32ByPathOrNull(this JArray? array, string path) {
        return JsonTokenUtils.ParseUInt32OrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="uint"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="uint"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetUInt32(this JArray? array, int index, out uint result) {
        return JsonTokenUtils.TryParseUInt32(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="uint"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="uint"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetUInt32(this JArray? array, int index, [NotNullWhen(true)] out uint? result) {
        return JsonTokenUtils.TryParseUInt32(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="uint"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="uint"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetUInt32ByPath(this JArray? array, string path, out uint result) {
        return JsonTokenUtils.TryParseUInt32(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="uint"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="uint"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetUInt32ByPath(this JArray? array, string path, [NotNullWhen(true)] out uint? result) {
        return JsonTokenUtils.TryParseUInt32(array?.SelectToken(path), out result);
    }

}