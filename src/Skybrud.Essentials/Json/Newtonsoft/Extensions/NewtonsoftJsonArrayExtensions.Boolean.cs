using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Json.Newtonsoft.Parsing.JsonTokenUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool GetBoolean(this JArray? array, int index) {
        return TryParseBoolean(GetToken(array, index), out bool result) && result;
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool? GetBoolean(this JArray? array, int index, bool fallback) {
        return TryParseBoolean(GetToken(array, index), out bool result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this JArray? array, int index) {
        return TryParseBoolean(GetToken(array, index), out bool result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>,
    /// <see langword="false"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool GetBooleanByPath(this JArray? array, string path) {
        return ParseBoolean(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBooleanByPath(this JArray? array, string path, bool fallback) {
        return ParseBoolean(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="bool"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanByPathOrNull(this JArray? array, string path) {
        return ParseBooleanOrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="bool"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this JArray? array, int index, out bool result) {
        return TryParseBoolean(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="bool"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetBoolean(this JArray? array, int index, [NotNullWhen(true)] out bool? result) {
        return TryParseBoolean(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="bool"/>; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanByPath(this JArray? array, string path, out bool result) {
        return TryParseBoolean(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="bool"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetBooleanByPath(this JArray? array, string path, [NotNullWhen(true)] out bool? result) {
        return TryParseBoolean(array?.SelectToken(path), out result);
    }

}