using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Extensions {

    public static partial class JArrayExtensions {

        /// <summary>
        /// Returns the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JArray? array, int index) {
            return JsonTokenUtils.GetBoolean(array?[index], false);
        }

        /// <summary>
        /// Returns the <see cref="bool"/> value of the item at the specified <paramref name="index"/> in the array, or
        /// <paramref name="fallback"/> of a matching token isn't found or the token value can not be parsed to a
        /// boolean value.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the token.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JArray? array, int index, bool fallback) {
            return JsonTokenUtils.GetBoolean(array?[index], fallback);
        }

        /// <summary>
        /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JArray? array, string path) {
            return JsonTokenUtils.GetBoolean(array?.SelectToken(path), false);
        }

        /// <summary>
        /// Gets the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>, or
        /// <paramref name="fallback"/> of a matching token isn't found or the token value can not be parsed to a
        /// boolean value.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="bool"/>.</returns>
        public static bool GetBoolean(this JArray? array, string path, bool fallback) {
            return JsonTokenUtils.GetBoolean(array?.SelectToken(path), fallback);
        }

        /// <summary>
        /// Attempts to get a boolean value from the token with the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the token.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBoolean(this JArray? array, int index, out bool result) {
            return JsonTokenUtils.TryGetBoolean(array?[index], out result);
        }

        /// <summary>
        /// Attempts to get a boolean value from the token with the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBoolean(this JArray? array, string path, out bool result) {
            return JsonTokenUtils.TryGetBoolean(array?.SelectToken(path), out result);
        }

    }

}