using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="double"/> value of the property with the specified <paramref name="propertyName"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="double"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDouble(this JObject? json, string propertyName) {
            return Parsing.JsonTokenUtils.GetDouble(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="double"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to a <see cref="double"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDouble(this JObject? json, string propertyName, double fallback) {
            return Parsing.JsonTokenUtils.GetDouble(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to a <see cref="double"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="double"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetDouble<T>(this JObject? json, string propertyName, Func<double, T> callback) {
            return Parsing.JsonTokenUtils.GetDouble(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching token can not be found or the value can not be successfully converted to a
        /// <see cref="double"/> value, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDoubleByPath(this JObject? json, string path) {
            return Parsing.JsonTokenUtils.GetDouble(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="double"/> value of the token matching the specified <paramref name="path"/>. If a
        /// matching token can not be found or the value can not be successfully converted to a <see cref="double"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDoubleByPath(this JObject? json, string path, double fallback) {
            return Parsing.JsonTokenUtils.GetDouble(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
        /// to a <see cref="double"/> value, the default value of <typeparamref name="T"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="double"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetDoubleByPath<T>(this JObject? json, string path, Func<double, T> callback) {
            return Parsing.JsonTokenUtils.GetDouble(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Attempts to get a <see cref="double"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="double"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this JObject? json, string propertyName, out double result) {
            return Parsing.JsonTokenUtils.TryGetDouble(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="double"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this JObject? json, string propertyName, [NotNullWhen(true)] out double? result) {
            return Parsing.JsonTokenUtils.TryGetDouble(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="double"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDoubleByPath(this JObject? json, string path, out double result) {
            return Parsing.JsonTokenUtils.TryGetDouble(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get a <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="double"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDoubleByPath(this JObject? json, string path, [NotNullWhen(true)] out double? result) {
            return Parsing.JsonTokenUtils.TryGetDouble(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="double"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="double"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="double"/>.</returns>
        public static double[] GetDoubleArray(this JObject? json, string propertyName) {
            return Parsing.JsonTokenUtils.GetDoubleArray(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
        /// found, the value is not an array or the value can not be successfully converted, an empty array of
        /// <see cref="double"/> is returned instead.
        /// </summary>
        /// <returns>An array of <see cref="double"/>.</returns>
        public static double[] GetDoubleArrayByPath(this JObject? json, string path) {
            return Parsing.JsonTokenUtils.GetDoubleArray(json?.SelectToken(path));
        }

    }

}