using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="ulong"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt64(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to an <see cref="ulong"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64(this JObject? json, string propertyName, ulong fallback) {
            return JsonTokenUtils.GetUInt64(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to an <see cref="ulong"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="ulong"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt64<T>(this JObject? json, string propertyName, Func<ulong, T> callback) {
            return JsonTokenUtils.GetUInt64(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="ulong"/> value, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="ulong"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ulong? GetUInt64OrNull(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt64OrNull(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="ulong"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64ByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt64(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to an <see cref="ulong"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64ByPath(this JObject? json, string path, ulong fallback) {
            return JsonTokenUtils.GetUInt64(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to an <see cref="ulong"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="ulong"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt64ByPath<T>(this JObject? json, string path, Func<ulong, T> callback) {
            return JsonTokenUtils.GetUInt64(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Returns the <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="ulong"/> value,<see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ulong"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ulong? GetUInt64OrNullByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt64OrNull(json?.SelectToken(path));
        }

        /// <summary>
        /// Attempts to get an <see cref="ulong"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ulong"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt64(this JObject? json, string propertyName, out ulong result) {
            return JsonTokenUtils.TryGetUInt64(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ulong"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt64(this JObject? json, string propertyName, [NotNullWhen(true)] out ulong? result) {
            return JsonTokenUtils.TryGetUInt64(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ulong"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt64ByPath(this JObject? json, string path, out ulong result) {
            return JsonTokenUtils.TryGetUInt64(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ulong"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt64ByPath(this JObject? json, string path, [NotNullWhen(true)] out ulong? result) {
            return JsonTokenUtils.TryGetUInt64(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="ulong"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="ulong"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="ulong"/>.</returns>
        public static ulong[] GetUInt64Array(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt64Array(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="ulong"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="ulong"/>.</returns>
        public static ulong[] GetUInt64ArrayByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt64Array(json?.SelectToken(path));
        }

    }

}