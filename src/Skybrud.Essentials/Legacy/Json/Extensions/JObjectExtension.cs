using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;

// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Json.Extensions {

    /// <summary>
    /// Various extensions methods for <see cref="JObject"/> that makes manual parsing easier.
    /// </summary>
    [Obsolete]
    public static class JObjectExtension {

        /// <summary>
        /// Gets whether a token matching the specified <paramref name="path"/> exists and isn't <c>null</c> (or an empty string).
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns><c>true</c> if the property exists and the value isn't <c>null</c>, otherwise <c>false</c>.</returns>
        [Obsolete]
        public static bool HasValue(JObject obj, string path) {
            return obj.HasValue(path);
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        [Obsolete]
        public static JObject? GetObject(JObject obj, string path) {
            return obj.GetObject(path);
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not found.</returns>
        [Obsolete]
        public static T? GetObject<T>(JObject obj, string path) {
            return obj.GetObject<T>(path);
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not found.</returns>
        [Obsolete]
        public static T? GetObject<T>(JObject obj, string path, Func<JObject, T> func) {
            return obj.GetObject(path, func);
        }

        /// <summary>
        /// Gets the string value of the token matching the specified <paramref name="path"/>, or <c>null</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="String"/>, or <c>null</c>.</returns>
        [Obsolete]
        public static string? GetString(JObject obj, string path) {
            return obj.GetString(path);
        }

        /// <summary>
        /// Gets the value of the token matching the specified <paramref name="path"/>, or <c>null</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the string value.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c>.</returns>
        [Obsolete]
        public static T? GetString<T>(JObject obj, string path, Func<string, T> callback) {
            return obj.GetString(path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int32"/>.</returns>
        [Obsolete]
        public static int GetInt32(JObject obj, string path) {
            return obj.GetInt32(path);
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <typeparam name="T">The type of the parsed type.</typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        /// <returns>An instance of <see cref="System.Int32"/>, or <c>0</c> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        [Obsolete]
        public static T? GetInt32<T>(JObject obj, string path, Func<int, T> callback) {
            return obj.GetInt32(path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        [Obsolete]
        public static long GetInt64(JObject obj, string path) {
            return obj.GetInt64(path);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the token value.</param>
        /// <returns>An instance of <see cref="System.Int64"/>, or <c>0</c> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        [Obsolete]
        public static T? GetInt64<T>(JObject obj, string path, Func<long, T> callback) {
            return obj.GetInt64(path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        [Obsolete]
        public static float GetFloat(JObject obj, string path) {
            return obj.GetFloat(path);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Single"/>, or <c>0</c> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        [Obsolete]
        public static T? GetFloat<T>(JObject obj, string path, Func<float, T> callback) {
            return obj.GetFloat(path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Double"/>.</returns>
        [Obsolete]
        public static double GetDouble(JObject obj, string path) {
            return obj.GetDouble(path);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Double"/>, or <c>0</c> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        [Obsolete]
        public static T? GetDouble<T>(JObject obj, string path, Func<double, T> callback) {
            return obj.GetDouble(path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Boolean"/>.</returns>
        [Obsolete]
        public static bool GetBoolean(JObject obj, string path) {
            return obj.GetBoolean(path);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <paramref name="path"/> and
        /// parses it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/>
        /// doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Boolean"/>, or <c>false</c> if <paramref name="path"/>
        /// doesn't match a token.</returns>
        [Obsolete]
        public static T? GetBoolean<T>(JObject obj, string path, Func<bool, T> callback) {
            return obj.GetBoolean(path, callback);
        }

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        [Obsolete]
        public static T GetEnum<T>(JObject obj, string path) where T : struct {
            return EnumUtils.ParseEnum<T>(GetString(obj, path));
        }

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        [Obsolete]
        public static T GetEnum<T>(JObject obj, string path, T fallback) where T : struct {
            return obj.GetEnum(path, fallback);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the value of the property.</returns>
        [Obsolete]
        public static DateTime GetDateTime(JObject? obj, string path) {
            return obj.GetDateTime(path);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that indicates the style elements that
        /// can be present in the property value for the parse operation to succeed and that defines how to interpret
        /// the parsed date in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="System.Globalization.DateTimeStyles.None"/>.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the value of the property.</returns>
        [Obsolete]
        public static DateTime GetDateTime(JObject obj, string path, DateTimeStyles styles) {
            return obj.GetString(path, x => DateTime.Parse(x, CultureInfo.InvariantCulture, styles));
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about the property value.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that indicates the style elements that
        /// can be present in the property value for the parse operation to succeed and that defines how to interpret
        /// the parsed date in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="System.Globalization.DateTimeStyles.None"/>.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the value of the property.</returns>
        [Obsolete]
        public static DateTime GetDateTime(JObject obj, string path, IFormatProvider provider, DateTimeStyles styles) {
            return obj.GetString(path, x => DateTime.Parse(x, provider, styles));
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JArray"/>, or <c>null</c> if not found.</returns>
        [Obsolete]
        public static JArray? GetArray(JObject obj, string path) {
            return obj.GetArray(path);
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the property matching the specified <paramref name="path"/> using the
        /// specified delegate <paramref name="callback"/> for parsing each item in the array.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        [Obsolete]
        public static T[]? GetArray<T>(JObject obj, string path, Func<JObject, T> callback) {
            return obj.GetArray(path, callback);
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An array of <see cref="JToken"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        [Obsolete]
        public static JToken[] GetArrayItems(JObject obj, string path) {
            return obj.GetArrayItems(path);
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        [Obsolete]
        public static T[] GetArrayItems<T>(JObject obj, string path) {
            return obj.GetArrayItems<T>(path);
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        [Obsolete]
        public static T[] GetArrayItems<T>(JObject obj, string path, Func<JToken, T> callback) {
            return obj.GetArrayItems(path, callback);
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        [Obsolete]
        public static T[] GetArrayItems<T>(JObject obj, string path, Func<JObject, T> callback) {
            return obj.GetArrayItems(path, callback);
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="TValue"/>. If the a matching token isn't found, an empty
        /// array will still be returned.</returns>
        [Obsolete]
        public static TValue[] GetArrayItems<TKey, TValue>(JObject obj, string path, Func<TKey, TValue> callback) where TKey : JToken {
            return obj.GetArrayItems(path, callback);
        }

        /// <summary>
        /// Gets an array of <see cref="string"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="System.String"/>.</returns>
        [Obsolete]
        public static string[] GetStringArray(JObject? obj, string path) {
            return obj.GetStringArray(path);
        }

        /// <summary>
        /// Gets an array of <see cref="int"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="int"/>.</returns>
        [Obsolete]
        public static int[] GetInt32Array(JObject? obj, string path) {
            return obj.GetInt32Array(path);
        }

        /// <summary>
        /// Gets an array of <see cref="long"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="long"/>.</returns>
        [Obsolete]
        public static long[] GetInt64Array(JObject? obj, string path) {
            return obj.GetInt64Array(path);
        }

    }

}