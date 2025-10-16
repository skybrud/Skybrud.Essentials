using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <c>0</c>.</returns>
    public static ushort GetUInt16(this JArray? array, int index) {
        return JsonTokenUtils.TryParseUInt16(JsonTokenUtils.GetToken(array, index), out ushort result) ? result : (ushort) 0;
    }

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static ushort? GetUInt16(this JArray? array, int index, ushort fallback) {
        return JsonTokenUtils.TryParseUInt16(JsonTokenUtils.GetToken(array, index), out ushort result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static ushort? GetUInt16OrNull(this JArray? array, int index) {
        return JsonTokenUtils.TryParseUInt16(JsonTokenUtils.GetToken(array, index), out ushort result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <c>0</c>.</returns>
    public static ushort GetUInt16ByPath(this JArray? array, string path) {
        return JsonTokenUtils.ParseUInt16(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static ushort GetUInt16ByPath(this JArray? array, string path, ushort fallback) {
        return JsonTokenUtils.ParseUInt16(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="ushort"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static ushort? GetUInt16ByPathOrNull(this JArray? array, string path) {
        return JsonTokenUtils.ParseUInt16OrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="ushort"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="ushort"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetUInt16(this JArray? array, int index, out ushort result) {
        return JsonTokenUtils.TryParseUInt16(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="ushort"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="ushort"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetUInt16(this JArray? array, int index, [NotNullWhen(true)] out ushort? result) {
        return JsonTokenUtils.TryParseUInt16(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="ushort"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="ushort"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetUInt16ByPath(this JArray? array, string path, out ushort result) {
        return JsonTokenUtils.TryParseUInt16(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="ushort"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="ushort"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetUInt16ByPath(this JArray? array, string path, [NotNullWhen(true)] out ushort? result) {
        return JsonTokenUtils.TryParseUInt16(array?.SelectToken(path), out result);
    }

}