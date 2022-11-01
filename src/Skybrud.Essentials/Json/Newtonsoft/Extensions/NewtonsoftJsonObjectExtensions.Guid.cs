using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="Guid"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to an <see cref="Guid"/>
        /// value, <see langword="false"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetGuid(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="Guid"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to an <see cref="Guid"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JObject? json, string propertyName, Guid fallback) {
            return JsonTokenUtils.GetGuid(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
        /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
        /// successfully converted to a <see cref="Guid"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the <see cref="Guid"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetGuid<T>(this JObject? json, string propertyName, Func<Guid, T> callback) {
            return JsonTokenUtils.GetGuid(json?[propertyName], callback);
        }

        /// <summary>
        /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If
        /// a matching token can not be found or the value can not be successfully converted to an <see cref="Guid"/>
        /// value, <see langword="false"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuidByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetGuid(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If
        /// a matching token can not be found or the value can not be successfully converted to an <see cref="Guid"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuidByPath(this JObject? json, string path, Guid fallback) {
            return JsonTokenUtils.GetGuid(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
        /// <paramref name="path"/>. If a matching token can not be found or the value can not be
        /// successfully converted to a <see cref="Guid"/> value, the default value of <typeparamref name="T"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="json"></param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the <see cref="Guid"/> value.</param>
        /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public static T? GetGuidByPath<T>(this JObject? json, string path, Func<Guid, T> callback) {
            return JsonTokenUtils.GetGuid(json?.SelectToken(path), callback);
        }

        /// <summary>
        /// Attempts to get an <see cref="Guid"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this JObject? json, string propertyName, out Guid result) {
            return JsonTokenUtils.TryGetGuid(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="Guid"/> value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this JObject? json, string propertyName, [NotNullWhen(true)] out Guid? result) {
            return JsonTokenUtils.TryGetGuid(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="Guid"/> value from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <c>0</c>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuidByPath(this JObject? json, string path, out Guid result) {
            return JsonTokenUtils.TryGetGuid(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get an <see cref="Guid"/> value from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuidByPath(this JObject? json, string path, [NotNullWhen(true)] out Guid? result) {
            return JsonTokenUtils.TryGetGuid(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
        /// <see cref="Guid"/>. If a matching property is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="Guid"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] GetGuidArray(this JObject? json, string propertyName) {
            return JsonTokenUtils.GetGuidArray(json?[propertyName]);
        }

        /// <summary>
        /// Returns the value of the token matching the specified <paramref name="path"/> as an array of
        /// <see cref="Guid"/>. If a matching token is not found, the value is not an array or the value can not be
        /// successfully converted, an empty array of <see cref="Guid"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] GetGuidArrayByPath(this JObject? json, string path) {
            return JsonTokenUtils.GetGuidArray(json?.SelectToken(path));
        }

    }

}