using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to a <see cref="bool"/>
        /// value, <c>false</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JObject? json, string propertyName) {
            return Parsing.JsonTokenUtils.GetBoolean(json?[propertyName]);
        }

        /// <summary>
        /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If
        /// a matching property can not be found or the value can not be successfully converted to a <see cref="bool"/>
        /// value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JObject? json, string propertyName, bool fallback) {
            return Parsing.JsonTokenUtils.GetBoolean(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="bool"/> value, <c>false</c> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBooleanByPath(this JObject? json, string path) {
            return Parsing.JsonTokenUtils.GetBoolean(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
        /// If a matching property can not be found or the value can not be successfully converted to a
        /// <see cref="bool"/> value, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBooleanByPath(this JObject? json, string path, bool fallback) {
            return Parsing.JsonTokenUtils.GetBoolean(json?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Attempts to get a boolean value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBoolean(this JObject? json, string propertyName, out bool result) {
            return Parsing.JsonTokenUtils.TryGetBoolean(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a boolean value from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBoolean(this JObject? json, string propertyName, [NotNullWhen(true)] out bool? result) {
            return Parsing.JsonTokenUtils.TryGetBoolean(json?[propertyName], out result);
        }

        /// <summary>
        /// Attempts to get a boolean value from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBooleanByPath(this JObject? json, string path, out bool result) {
            return Parsing.JsonTokenUtils.TryGetBoolean(json?.SelectToken(path), out result);
        }

        /// <summary>
        /// Attempts to get a boolean value from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBooleanByPath(this JObject? json, string path, [NotNullWhen(true)] out bool? result) {
            return Parsing.JsonTokenUtils.TryGetBoolean(json?.SelectToken(path), out result);
        }

    }

}