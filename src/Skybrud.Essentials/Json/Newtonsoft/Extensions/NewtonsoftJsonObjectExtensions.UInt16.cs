using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="ushort"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt16(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to an <see cref="ushort"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16(this JObject? json, string propertyName, ushort fallback) {
            return JsonTokenUtils.GetUInt16(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to an <see cref="ushort"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="ushort"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt16<T>(this JObject? json, string propertyName, Func<ushort, T> callback) {
            return JsonTokenUtils.GetUInt16(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="ushort"/> value, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ushort? GetUInt16OrNull(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt16OrNull(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="ushort"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16ByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt16(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to an <see cref="ushort"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16ByPath(this JObject? json, string path, ushort fallback) {
            return JsonTokenUtils.GetUInt16(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to an <see cref="ushort"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="ushort"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt16ByPath<T>(this JObject? json, string path, Func<ushort, T> callback) {
            return JsonTokenUtils.GetUInt16(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Returns the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="ushort"/> value,<see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ushort? GetUInt16OrNullByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt16OrNull(json?.SelectToken(path));
        }

        /// <summary>
        /// Attempts to get an <see cref="ushort"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ushort"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt16(this JObject? json, string propertyName, out ushort result) {
            return JsonTokenUtils.TryGetUInt16(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ushort"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt16(this JObject? json, string propertyName, [NotNullWhen(true)] out ushort? result) {
            return JsonTokenUtils.TryGetUInt16(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ushort"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt16ByPath(this JObject? json, string path, out ushort result) {
            return JsonTokenUtils.TryGetUInt16(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="ushort"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt16ByPath(this JObject? json, string path, [NotNullWhen(true)] out ushort? result) {
            return JsonTokenUtils.TryGetUInt16(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="ushort"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="ushort"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="ushort"/>.</returns>
        public static ushort[] GetUInt16Array(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt16Array(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="ushort"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="ushort"/>.</returns>
        public static ushort[] GetUInt16ArrayByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt16Array(json?.SelectToken(path));
        }

    }

}