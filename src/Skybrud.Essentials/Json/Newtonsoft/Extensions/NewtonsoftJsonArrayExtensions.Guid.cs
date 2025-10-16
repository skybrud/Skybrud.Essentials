using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Json.Newtonsoft.Parsing.JsonTokenUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>,
    /// <see cref="Guid.Empty"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuid(this JArray? array, int index) {
        return TryParseGuid(GetToken(array, index), out Guid result) ? result : Guid.Empty;
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid? GetGuid(this JArray? array, int index, Guid fallback) {
        return TryParseGuid(GetToken(array, index), out Guid result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this JArray? array, int index) {
        return TryParseGuid(GetToken(array, index), out Guid result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>,
    /// <see cref="Guid.Empty"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuidByPath(this JArray? array, string path) {
        return ParseGuid(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid GetGuidByPath(this JArray? array, string path, Guid fallback) {
        return ParseGuid(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="Guid"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidByPathOrNull(this JArray? array, string path) {
        return ParseGuidOrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="Guid"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="Guid"/>; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static bool TryGetGuid(this JArray? array, int index, out Guid result) {
        return TryParseGuid(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="Guid"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="Guid"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetGuid(this JArray? array, int index, [NotNullWhen(true)] out Guid? result) {
        return TryParseGuid(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="Guid"/>; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static bool TryGetGuidByPath(this JArray? array, string path, out Guid result) {
        return TryParseGuid(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="Guid"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetGuidByPath(this JArray? array, string path, [NotNullWhen(true)] out Guid? result) {
        return TryParseGuid(array?.SelectToken(path), out result);
    }

}