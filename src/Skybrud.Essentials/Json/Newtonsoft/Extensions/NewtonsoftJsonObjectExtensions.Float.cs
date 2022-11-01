using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="float"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="float"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float GetFloat(this JObject? json, string propertyName) {
            return Parsing.JsonTokenUtils.GetFloat(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="float"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to a <see cref="float"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float GetFloat(this JObject? json, string propertyName, float fallback) {
            return Parsing.JsonTokenUtils.GetFloat(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to a <see cref="float"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="float"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetFloat<T>(this JObject? json, string propertyName, Func<float, T> callback) {
            return Parsing.JsonTokenUtils.GetFloat(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="float"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="float"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float GetFloatByPath(this JObject? json, string path) {
            return Parsing.JsonTokenUtils.GetFloat(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="float"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to a <see cref="float"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float GetFloatByPath(this JObject? json, string path, float fallback) {
            return Parsing.JsonTokenUtils.GetFloat(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to a <see cref="float"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="float"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetFloatByPath<T>(this JObject? json, string path, Func<float, T> callback) {
            return Parsing.JsonTokenUtils.GetFloat(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Attempts to get a <see cref="float"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="float"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this JObject? json, string propertyName, out float result) {
            return Parsing.JsonTokenUtils.TryGetFloat(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="float"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this JObject? json, string propertyName, [NotNullWhen(true)] out float? result) {
            return Parsing.JsonTokenUtils.TryGetFloat(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="float"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="float"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloatByPath(this JObject? json, string path, out float result) {
            return Parsing.JsonTokenUtils.TryGetFloat(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="float"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="float"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloatByPath(this JObject? json, string path, [NotNullWhen(true)] out float? result) {
            return Parsing.JsonTokenUtils.TryGetFloat(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="float"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="float"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="float"/>.</returns>
        public static float[] GetFloatArray(this JObject? json, string propertyName) {
            return Parsing.JsonTokenUtils.GetFloatArray(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="float"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="float"/>.</returns>
        public static float[] GetFloatArrayByPath(this JObject? json, string path) {
            return Parsing.JsonTokenUtils.GetFloatArray(json?.SelectToken(path));
        }

    }

}