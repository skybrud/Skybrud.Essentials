using Newtonsoft.Json.Linq;
using System;

namespace Skybrud.Essentials.Json.Extensions {

    public static partial class JObjectExtensions {

        /// <summary>
        /// Gets the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JObject obj, string path) {
            return JsonTokenUtils.GetBoolean(obj?.SelectToken(path), false);
        }

        /// <summary>
        /// Gets the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>, or
        /// <paramref name="fallback"/> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JObject obj, string path, bool fallback) {
            return JsonTokenUtils.GetBoolean(obj?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Gets the <see cref="bool"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if
        /// <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="bool"/>, or <c>false</c> if <paramref name="path"/>
        /// doesn't match a token.</returns>
        public static T GetBoolean<T>(this JObject obj, string path, Func<bool, T> callback) {
            return JsonTokenUtils.TryGetBoolean(obj?.SelectToken(path), out bool result) ? callback(result) : default;
        }

        /// <summary>
        /// Attempts to get a boolean value from the token with the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBoolean(this JObject obj, string path, out bool result) {
            return JsonTokenUtils.TryGetBoolean(obj?.SelectToken(path), out result);
        }

    }

}