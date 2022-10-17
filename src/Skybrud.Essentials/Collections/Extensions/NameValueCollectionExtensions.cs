#if NET_FRAMEWORK

using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Collections.Extensions {

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
        public static bool GetBoolean(this NameValueCollection? collection, string key) {
            return StringUtils.ParseBoolean(collection?[key]);
        }

        /// <summary>
        /// Returns the boolean value of the item with <paramref name="key"/>. If an matching isn't found, or conversion to a boolean representation failed, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The converted value of the item with <paramref name="key"/> if the conversion was successful; otherwise <paramref name="fallback"/>.</returns>
        public static bool GetBoolean(this NameValueCollection? collection, string key, bool fallback) {
            return StringUtils.ParseBoolean(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the boolean value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the boolean value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>false</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetBoolean(this NameValueCollection? collection, string key, out bool result) {
            return StringUtils.TryParseBoolean(collection?[key], out result);
        }

        /// <summary>
        /// Gets the boolean value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the boolean value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetBoolean(this NameValueCollection? collection, string key, [NotNullWhen(true)] out bool? result) {
            return StringUtils.TryParseBoolean(collection?[key], out result);
        }

        /// <summary>
        /// Returns the GUID value of the item with <paramref name="key"/>. If an matching isn't found, or conversion to a GUID failed, <see cref="Guid.Empty"/> is returned instead.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The converted value of the item with <paramref name="key"/> if the conversion was successful; otherwise <c>false</c>.</returns>
        public static Guid GetGuid(this NameValueCollection? collection, string key) {
            return StringUtils.ParseGuid(collection?[key]);
        }

        /// <summary>
        /// Returns the GUID value of the item with <paramref name="key"/>. If an matching isn't found, or conversion to a GUID failed, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The converted value of the item with <paramref name="key"/> if the conversion was successful; otherwise <paramref name="fallback"/>.</returns>
        public static Guid GetGuid(this NameValueCollection? collection, string key, Guid fallback) {
            return StringUtils.ParseGuid(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the boolean value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the GUID value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <see cref="Guid.Empty"/>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetGuid(this NameValueCollection? collection, string key, out Guid result) {
            return StringUtils.TryParseGuid(collection?[key], out result);
        }

        /// <summary>
        /// Gets the boolean value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the GUID value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetGuid(this NameValueCollection? collection, string key, [NotNullWhen(true)] out Guid? result) {
            return StringUtils.TryParseGuid(collection?[key], out result);
        }

        /// <summary>
        /// Returns the <see cref="int"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a 32-bit unsigned integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The value as a 32-bit unsigned integer (<see cref="int"/>).</returns>
        public static int GetInt32(this NameValueCollection? collection, string key) {
            return StringUtils.ParseInt32(collection?[key]);
        }

        /// <summary>
        ///  Returns the <see cref="int"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a 32-bit unsigned integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The value as a 32-bit unsigned integer (<see cref="int"/>).</returns>
        public static int GetInt32(this NameValueCollection? collection, string key, int fallback) {
            return StringUtils.ParseInt32(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the <see cref="int"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="int"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetInt32(this NameValueCollection? collection, string key, out int result) {
            return StringUtils.TryParseInt32(collection?[key], out result);
        }

        /// <summary>
        /// Gets the <see cref="int"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="int"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetInt32(this NameValueCollection? collection, string key, [NotNullWhen(true)] out int? result) {
            return StringUtils.TryParseInt32(collection?[key], out result);
        }

        /// <summary>
        /// Returns the <see cref="long"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a 64-bit unsigned integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The value as a 64-bit unsigned integer (<see cref="long"/>).</returns>
        public static long GetInt64(this NameValueCollection? collection, string key) {
            return StringUtils.ParseInt64(collection?[key]);
        }

        /// <summary>
        ///  Returns the <see cref="long"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a 64-bit unsigned integer.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The value as a 64-bit unsigned integer (<see cref="long"/>).</returns>
        public static long GetInt64(this NameValueCollection? collection, string key, int fallback) {
            return StringUtils.ParseInt64(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the <see cref="long"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="long"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetInt64(this NameValueCollection? collection, string key, out long result) {
            return StringUtils.TryParseInt64(collection?[key], out result);
        }

        /// <summary>
        /// Gets the <see cref="long"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="long"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetInt64(this NameValueCollection? collection, string key, [NotNullWhen(true)] out long? result) {
            return StringUtils.TryParseInt64(collection?[key], out result);
        }

        /// <summary>
        /// Returns the <see cref="float"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a single-precision floating-point number.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The value as a single-precision floating-point number (<see cref="float"/>).</returns>
        public static float GetFloat(this NameValueCollection? collection, string key) {
            return StringUtils.ParseFloat(collection?[key]);
        }

        /// <summary>
        ///  Returns the <see cref="float"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a single-precision floating-point number.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The value as a single-precision floating-point number (<see cref="float"/>).</returns>
        public static float GetFloat(this NameValueCollection? collection, string key, int fallback) {
            return StringUtils.ParseFloat(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the <see cref="float"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="float"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetFloat(this NameValueCollection? collection, string key, out float result) {
            return StringUtils.TryParseFloat(collection?[key], out result);
        }

        /// <summary>
        /// Gets the <see cref="float"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="float"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetFloat(this NameValueCollection? collection, string key, [NotNullWhen(true)] out float? result) {
            return StringUtils.TryParseFloat(collection?[key], out result);
        }

        /// <summary>
        /// Returns the <see cref="long"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a double-precision floating-point number.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns>The value as a double-precision floating-point number (<see cref="double"/>).</returns>
        public static double GetDouble(this NameValueCollection? collection, string key) {
            return StringUtils.ParseDouble(collection?[key]);
        }

        /// <summary>
        ///  Returns the <see cref="long"/> value of the item with the specified <paramref name="key"/>, or <c>0</c> if a matching item couldn't be found or the value couldn't be parsed to a double-precision floating-point number.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>The value as a double-precision floating-point number (<see cref="double"/>).</returns>
        public static double GetDouble(this NameValueCollection? collection, string key, double fallback) {
            return StringUtils.ParseDouble(collection?[key], fallback);
        }

        /// <summary>
        /// Gets the <see cref="long"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="double"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetDouble(this NameValueCollection? collection, string key, out double result) {
            return StringUtils.TryParseDouble(collection?[key], out result);
        }

        /// <summary>
        /// Gets the <see cref="long"/> value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the <see cref="long"/> value associated with the specified key, if the key is found and the the conversion succeeded; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> was found converted successfully; otherwise, <c>false.</c></returns>
        public static bool TryGetDouble(this NameValueCollection? collection, string key, [NotNullWhen(true)] out double? result) {
            return StringUtils.TryParseDouble(collection?[key], out result);
        }

        /// <summary>
        /// Gets the value associated with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <param name="result">When this method returns, contains the value associated with the specified key, if the key is found; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if the <see cref="NameValueCollection"/> contains an element with the specified key; otherwise, <c>false</c>.</returns>
        public static bool TryGetValue(this NameValueCollection? collection, string key, [NotNullWhen(true)] out string? result) {
            result = collection?[key];
            return result != null;
        }

        /// <summary>
        /// Returns whether <paramref name="collection"/> contains an item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key of the item.</param>
        /// <returns><c>true</c> if an item with <paramref name="key"/> is found; otherwise, <c>false</c>.</returns>
        public static bool ContainsKey(this NameValueCollection? collection, string key) {
            return collection is not null && collection.AllKeys.Any(x => x == key);
        }

    }

}

#endif