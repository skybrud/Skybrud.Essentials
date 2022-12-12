using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="uint"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="uint"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt32(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="uint"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to an <see cref="uint"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32(this JObject? json, string propertyName, uint fallback) {
            return JsonTokenUtils.GetUInt32(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to an <see cref="uint"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="uint"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt32<T>(this JObject? json, string propertyName, Func<uint, T> callback) {
            return JsonTokenUtils.GetUInt32(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="uint"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="uint"/> value, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static uint? GetUInt32OrNull(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt32OrNull(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="uint"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32ByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt32(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to an <see cref="uint"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32ByPath(this JObject? json, string path, uint fallback) {
            return JsonTokenUtils.GetUInt32(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to an <see cref="uint"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="uint"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetUInt32ByPath<T>(this JObject? json, string path, Func<uint, T> callback) {
            return JsonTokenUtils.GetUInt32(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Returns the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="uint"/> value,<see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static uint? GetUInt32OrNullByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt32OrNull(json?.SelectToken(path));
        }

        /// <summary>
        /// Attempts to get an <see cref="uint"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="uint"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt32(this JObject? json, string propertyName, out uint result) {
            return JsonTokenUtils.TryGetUInt32(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="uint"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt32(this JObject? json, string propertyName, [NotNullWhen(true)] out uint? result) {
            return JsonTokenUtils.TryGetUInt32(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="uint"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt32ByPath(this JObject? json, string path, out uint result) {
            return JsonTokenUtils.TryGetUInt32(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="uint"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="uint"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetUInt32ByPath(this JObject? json, string path, [NotNullWhen(true)] out uint? result) {
            return JsonTokenUtils.TryGetUInt32(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="uint"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="uint"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="uint"/>.</returns>
        public static uint[] GetUInt32Array(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetUInt32Array(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="uint"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="uint"/>.</returns>
        public static uint[] GetUInt32ArrayByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetUInt32Array(json?.SelectToken(path));
        }

    }

}