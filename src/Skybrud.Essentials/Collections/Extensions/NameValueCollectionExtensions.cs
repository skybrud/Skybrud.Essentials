using Skybrud.Essentials.Strings;
using System.Collections.Specialized;
using System.Linq;

namespace Skybrud.Essentials.Collections.Extensions {

#if NET_FRAMEWORK

    /// <summary>
    /// Class with various extension methods for <see cref="NameValueCollection"/>.
    /// </summary>
    public static class NameValueCollectionExtensions {

        /// <summary>
        /// Returns the boolean value of the item with <paramref name="key"/>. If an matching isn't found, or conversion to a boolean representation failed, <c>false</c> is returned instead.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The converted value of the item with <paramref name="key"/> if the conversion was successful; otherwise <c>false</c>.</returns>
        public static bool GetBoolean(this NameValueCollection collection, string key) {
            return StringUtils.ParseBoolean(collection[key]);
        }

        /// <summary>
        /// Returns the boolean value of the item with <paramref name="key"/>. If an matching isn't found, or conversion to a boolean representation failed, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The converted value of the item with <paramref name="key"/> if the conversion was successful; otherwise <paramref name="fallback"/>.</returns>
        public static bool GetBoolean(this NameValueCollection collection, string key, bool fallback) {
            return StringUtils.ParseBoolean(collection[key], fallback);
        }

        /// <summary>
        /// Gets the boolean value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the boolean value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>false</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetBoolean(this NameValueCollection collection, string key, out bool result) {
            return StringUtils.TryParseBoolean(collection[key], out result);
        }

        /// <summary>
        /// Returns the <see cref="int"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to an integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The value as an integer (<see cref="int"/>).</returns>
        public static int GetInt32(this NameValueCollection collection, string key) {
            return int.TryParse(collection[key], out int value) ? value : 0;
        }

        /// <summary>
        ///  Returns the <see cref="int"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to an integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The value as an integer (<see cref="int"/>).</returns>
        public static int GetInt32(this NameValueCollection collection, string key, int fallback) {
            return int.TryParse(collection[key], out int value) ? value : fallback;
        }

        /// <summary>
        /// Gets the <see cref="int"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="int"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetInt32(this NameValueCollection collection, string key, out int result) {
            return int.TryParse(collection[key], out result);
        }

        /// <summary>
        /// Gets the value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if the <see cref="NameValueCollection"/> contains an element with the specified key; otherwise, <c>false</c>.</returns>
        public static bool TryGetValue(this NameValueCollection collection, string key, out string result) {
            result = collection[key];
            return result != null;
        }

        /// <summary>
        /// Returns whether <paramref name="collection"/> contains an item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> is found; otherwise, <c>false</c>.</returns>
        public static bool ContainsKey(this NameValueCollection collection, string key) {
            return collection.AllKeys.Any(x => x == key);
        }

    }

#endif

}