﻿using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Extensions {

    /// <summary>
    /// Various extensions methods for <see cref="JArray"/> that makes manual parsing easier.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Extensions.JArrayExtensions' class instead.")]
    public static partial class JArrayExtensions {

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
        /// the object is parsed using the specified delegate <paramref name="func"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T? GetObject<T>(this JArray? array, int index, Func<JObject, T> func) {
            return array?[index] is JObject obj ? func(obj) : default;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        public static JObject? GetObject(this JArray? array, string path) {
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
        public static T? GetObject<T>(this JArray? array, string path) {
            return array?.SelectToken(path) is JObject child ? child.ToObject<T>() : default;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, the object
        /// is parsed using the specified delegate <paramref name="func"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T? GetObject<T>(this JArray? array, string path, Func<JObject, T> func) {
            return array?.SelectToken(path) is JObject obj ? func(obj) : default;
        }

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
        public static string? GetString(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<string>();
        }

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
        public static Guid GetGuid(this JArray? array, string path) {
            return GetGuid(array, path, Guid.Empty);
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
        public static Guid GetGuid(this JArray? array, string path, Guid fallback) {

            // Get the token at "index" (or return "fallback" if not found)
            JToken? token = array?.SelectToken(path);
            if (token == null) return fallback;

            // Attempt to parse the GUID (or return "fallback" if the parsing fails)
            return Guid.TryParse(token.Value<string>(), out Guid guid) ? guid : fallback;

        }

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
        public static short GetInt16(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<short>() ?? default;
        }

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
        public static ushort GetUInt16(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<ushort>() ?? default;
        }

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
        public static int GetInt32(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<int>() ?? default;
        }

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
        public static uint GetUInt32(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<uint>() ?? default;
        }

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
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<long>() ?? default;
        }

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
        public static ulong GetUInt64(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<ulong>() ?? default;
        }

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
        public static double GetDouble(this JArray? array, string path) {
            return array?.SelectToken(path)?.Value<double>() ?? default;
        }

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
        /// array using the specified delegate <paramref name="func"/> for parsing each item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[]? GetArray<T>(this JArray? array, int index, Func<JObject, T> func) {

            if (array?[index] is not JArray property) return null;

            return (
                from JObject child in property
                select func(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray? GetArray(this JArray? array, string path) {
            return array?.SelectToken(path) as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the from the token matching the specified
        /// <paramref name="path"/> in the array using the specified delegate <paramref name="func"/> for parsing each
        /// item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[]? GetArray<T>(this JArray? array, string path, Func<JObject, T> func) {

            if (array?.SelectToken(path) is not JArray token) return null;

            return (
                from JObject child in token
                select func(child)
            ).ToArray();

        }

    }

}