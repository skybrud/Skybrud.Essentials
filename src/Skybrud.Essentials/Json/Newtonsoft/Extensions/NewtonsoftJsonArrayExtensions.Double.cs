using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Json.Newtonsoft.Parsing.JsonTokenUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonArrayExtensions {

    /// <summary>
    /// Returns the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="double"/>,
    /// <c>0</c> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <c>0</c>.</returns>
    public static double GetDouble(this JArray? array, int index) {
        return TryParseDouble(GetToken(array, index), out double result) ? result : 0;
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="double"/>,
    /// <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double? GetDouble(this JArray? array, int index, double fallback) {
        return TryParseDouble(GetToken(array, index), out double result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array. If an
    /// item at <paramref name="index"/> isn&apos;t found, or the value cannot be converted to a <see cref="double"/>,
    /// <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this JArray? array, int index) {
        return TryParseDouble(GetToken(array, index), out double result) ? result : null;
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="double"/>, <c>0</c> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <c>0</c>.</returns>
    public static double GetDoubleByPath(this JArray? array, string path) {
        return ParseDouble(array?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="double"/>, <paramref name="fallback"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double GetDoubleByPath(this JArray? array, string path, double fallback) {
        return ParseDouble(array?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="double"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token isn&apos;t found, or the value cannot be converted to a <see cref="double"/>, <see langword="null"/> is
    /// returned instead.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleByPathOrNull(this JArray? array, string path) {
        return ParseDoubleOrNull(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="double"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetDouble(this JArray? array, int index, out double result) {
        return TryParseDouble(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches a <see cref="double"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetDouble(this JArray? array, int index, [NotNullWhen(true)] out double? result) {
        return TryParseDouble(GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="double"/>; otherwise, <c>0</c>.</returns>
    public static bool TryGetDoubleByPath(this JArray? array, string path, out double result) {
        return TryParseDouble(array?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches a <see cref="double"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetDoubleByPath(this JArray? array, string path, [NotNullWhen(true)] out double? result) {
        return TryParseDouble(array?.SelectToken(path), out result);
    }

}