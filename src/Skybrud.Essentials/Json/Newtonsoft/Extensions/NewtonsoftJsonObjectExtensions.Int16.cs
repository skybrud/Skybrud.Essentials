using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="short"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="short"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetInt16(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="short"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to a <see cref="short"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16(this JObject? json, string propertyName, short fallback) {
            return JsonTokenUtils.GetInt16(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to a <see cref="short"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="short"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetInt16<T>(this JObject? json, string propertyName, Func<short, T> callback) {
            return JsonTokenUtils.GetInt16(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="short"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16ByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetInt16(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to a <see cref="short"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16ByPath(this JObject? json, string path, short fallback) {
            return JsonTokenUtils.GetInt16(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to a <see cref="short"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="short"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetInt16ByPath<T>(this JObject? json, string path, Func<short, T> callback) {
            return JsonTokenUtils.GetInt16(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Attempts to get a <see cref="short"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt16(this JObject? json, string propertyName, out short result) {
            return JsonTokenUtils.TryGetInt16(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="short"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt16(this JObject? json, string propertyName, [NotNullWhen(true)] out short? result) {
            return JsonTokenUtils.TryGetInt16(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt16ByPath(this JObject? json, string path, out short result) {
            return JsonTokenUtils.TryGetInt16(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt16ByPath(this JObject? json, string path, [NotNullWhen(true)] out short? result) {
            return JsonTokenUtils.TryGetInt16(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="short"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="short"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="short"/>.</returns>
        public static short[] GetInt16Array(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetInt16Array(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="short"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="short"/>.</returns>
        public static short[] GetInt16ArrayByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetInt16Array(json?.SelectToken(path));
        }

    }

}