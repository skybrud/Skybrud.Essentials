using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    /// <summary>
    /// Static class with various extension methods for <see cref="JArray"/>.
    /// </summary>
    public static class NewtonsoftJsonArrayExtensions {

        #region System.Boolean

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
        public static bool GetBooleanByPath(this JArray? array, string path) {
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
        public static bool GetBooleanByPath(this JArray? array, string path, bool fallback) {
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
        public static bool TryGetBooleanByPath(this JArray? array, string path, out bool result) {
            return JsonTokenUtils.TryGetBoolean(array?.SelectToken(path), out result);
        }

        #endregion

        #region System.Double

        /// <summary>
        /// Gets the <see cref="double"/> value of the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDouble(this JArray? array, int index) {
            return array?[index]?.Value<double>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="double"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double GetDoubleByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<double>() ?? default;
        }

        #endregion

        #region System.Guid

        /// <summary>
        /// Gets the GUID value from <paramref name="array"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the item holding the GUID value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray? array, int index) {
            return GetGuid(array, index, Guid.Empty);
        }

        /// <summary>
        /// Gets the GUID value of the token matching the specified <paramref name="path"/>, or <see cref="Guid.Empty"/> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuidByPath(this JArray? array, string path) {
            return GetGuidByPath(array, path, Guid.Empty);
        }

        /// <summary>
        /// Gets the GUID value from <paramref name="array"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the item holding the GUID value.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray? array, int index, Guid fallback) {

            // Get the token at "index" (or return "fallback" if not found)
            JToken? token = array?[index];
            if (token == null) return fallback;

            // Attempt to parse the GUID (or return "fallback" if the parsing fails)
            return Guid.TryParse(token.Value<string>(), out Guid guid) ? guid : fallback;

        }

        /// <summary>
        /// Gets the GUID value of the token matching the specified <paramref name="path"/>, or the value of <paramref name="fallback"/> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuidByPath(this JArray? array, string path, Guid fallback) {

            // Get the token at "index" (or return "fallback" if not found)
            JToken? token = array?.SelectToken(path);
            if (token == null) return fallback;

            // Attempt to parse the GUID (or return "fallback" if the parsing fails)
            return Guid.TryParse(token.Value<string>(), out Guid guid) ? guid : fallback;

        }

        #endregion

        #region System.Int16

        /// <summary>
        /// Gets the <see cref="short"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16(this JArray? array, int index) {
            return array?[index]?.Value<short>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="short"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short GetInt16ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<short>() ?? default;
        }

        #endregion

        #region System.Int32

        /// <summary>
        /// Gets the <see cref="int"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int GetInt32(this JArray? array, int index) {
            return array?[index]?.Value<int>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="int"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int GetInt32ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<int>() ?? default;
        }

        #endregion

        #region System.Int64

        /// <summary>
        /// Gets the <see cref="long"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long GetInt64(this JArray? array, int index) {
            return array?[index]?.Value<long>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="long"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<long>() ?? default;
        }

        #endregion

        #region System.Object

        /// <summary>
        /// Gets an object from the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        public static JObject? GetObject(this JArray? array, int index) {
            return array?[index] as JObject;
        }

        /// <summary>
        /// Gets an object from the item at the specified <paramref name="index"/> in the array. If an object is found,
        /// it is parsed to the type of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not
        /// found.</returns>
        public static T? GetObject<T>(this JArray? array, int index) {
            if (array == null) return default;
            return array[index] is JObject child ? child.ToObject<T>() : default;
        }

        /// <summary>
        /// Gets an object from the item at the specified <paramref name="index"/> in the array. If an object is found,
        /// the object is parsed using the specified delegate <paramref name="callback"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="callback">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T? GetObject<T>(this JArray? array, int index, Func<JObject, T> callback) {
            return array?[index] is JObject obj ? callback(obj) : default;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        public static JObject? GetObjectByPath(this JArray? array, string path) {
            return array?.SelectToken(path) as JObject;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, it is
        /// parsed to the type of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not
        /// found.</returns>
        public static T? GetObjectByPath<T>(this JArray? array, string path) {
            return array?.SelectToken(path) is JObject child ? child.ToObject<T>() : default;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, the object
        /// is parsed using the specified delegate <paramref name="callback"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T? GetObjectByPath<T>(this JArray? array, string path, Func<JObject, T> callback) {
            return array?.SelectToken(path) is JObject obj ? callback(obj) : default;
        }

        #endregion

        #region System.String

        /// <summary>
        /// Gets a string from the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static string? GetString(this JArray? array, int index) {
            return array?[index]?.Value<string>();
        }

        /// <summary>
        /// Gets a string from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="string"/>, or <c>null</c> if <paramref name="path"/> didn't match
        /// any tokens.</returns>
        public static string? GetStringByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<string>();
        }

        #endregion

        #region System.UInt16

        /// <summary>
        /// Gets the <see cref="ushort"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16(this JArray? array, int index) {
            return array?[index]?.Value<ushort>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="ushort"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort GetUInt16ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<ushort>() ?? default;
        }

        #endregion

        #region System.UInt32

        /// <summary>
        /// Gets the <see cref="uint"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32(this JArray? array, int index) {
            return array?[index]?.Value<uint>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="uint"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint GetUInt32ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<uint>() ?? default;
        }

        #endregion

        #region System.UInt64

        /// <summary>
        /// Gets the <see cref="ulong"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64(this JArray? array, int index) {
            return array?[index]?.Value<ulong>() ?? default;
        }

        /// <summary>
        /// Gets the <see cref="ulong"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong GetUInt64ByPath(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<ulong>() ?? default;
        }

        #endregion

        #region Arrays

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray? GetArray(this JArray? array, int index) {
            return array?[index] as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the item at the specified <paramref name="index"/> in the
        /// array using the specified delegate <paramref name="callback"/> for parsing each item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="callback">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[]? GetArray<T>(this JArray? array, int index, Func<JObject, T> callback) {

            if (array?[index] is not JArray property) return null;

            return (
                from JObject child in property
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray? GetArrayByPath(this JArray? array, string path) {
            return array?.SelectToken(path) as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the from the token matching the specified
        /// <paramref name="path"/> in the array using the specified delegate <paramref name="callback"/> for parsing each
        /// item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="callback">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[]? GetArrayByPath<T>(this JArray? array, string path, Func<JObject, T> callback) {

            if (array?.SelectToken(path) is not JArray token) return null;

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        #endregion

    }

}