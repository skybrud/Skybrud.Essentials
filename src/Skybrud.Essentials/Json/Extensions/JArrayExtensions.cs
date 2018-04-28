using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Extensions {

    /// <summary>
    /// Various extensions methods for <see cref="JArray"/> that makes manual parsing easier.
    /// </summary>
    public static class JArrayExtensions {

        /// <summary>
        /// Gets an object from the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        public static JObject GetObject(this JArray array, int index) {
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
        public static T GetObject<T>(this JArray array, int index) {
            if (array == null) return default(T);
            JObject child = array[0] as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from the item at the specified <paramref name="index"/> in the array. If an object is found,
        /// the object is parsed using the specified delegate <paramref name="func"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetObject<T>(this JArray array, int index, Func<JObject, T> func) {
            return func(array == null ? null : array[index] as JObject);
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
        public static JObject GetObject(this JArray array, string path) {
            return array?.SelectToken(path) as JObject;
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, it is
        /// parsed to the type of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not
        /// found.</returns>
        public static T GetObject<T>(this JArray array, string path) {
            if (array == null) return default(T);
            JObject child = array.SelectToken(path) as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, the object
        /// is parsed using the specified delegate <paramref name="func"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetObject<T>(this JArray array, string path, Func<JObject, T> func) {
            return func(array == null ? null : array.SelectToken(path) as JObject);
        }

        /// <summary>
        /// Gets a string from the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static string GetString(this JArray array, int index) {
            JToken property = array?[index];
            return property == null ? null : property.Value<string>();
        }

        /// <summary>
        /// Gets a string from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="String"/>, or <c>null</c> if <paramref name="path"/> didn't match
        /// any tokens.</returns>
        public static string GetString(this JArray array, string path) {
            JToken token = array?.SelectToken(path);
            return token == null ? null : token.Value<string>();
        }

        /// <summary>
        /// Gets the GUID value from <paramref name="array"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the item holding the GUID value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray array, int index) {
            return GetGuid(array, index, Guid.Empty);
        }

        /// <summary>
        /// Gets the GUID value of the token matching the specified <paramref name="path"/>, or <see cref="Guid.Empty"/> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray array, string path) {
            return GetGuid(array, path, Guid.Empty);
        }

        /// <summary>
        /// Gets the GUID value from <paramref name="array"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index of the item holding the GUID value.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray array, int index, Guid fallback) {

            // Get the token at "index" (or return "fallback" if not found)
            JToken token = array?[index];
            if (token == null) return fallback;

            // Attempt to parse the GUID (or return "fallback" if the parsing fails)
            return Guid.TryParse(token.Value<string>(), out Guid guid) ? guid : fallback;

        }

        /// <summary>
        /// Gets the GUID value of the token matching the specified <paramref name="path"/>, or the value of <paramref name="fallback"/> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid GetGuid(this JArray array, string path, Guid fallback) {

            // Get the token at "index" (or return "fallback" if not found)
            JToken token = array?.SelectToken(path);
            if (token == null) return fallback;
            
            // Attempt to parse the GUID (or return "fallback" if the parsing fails)
            return Guid.TryParse(token.Value<string>(), out Guid guid) ? guid : fallback;

        }
        
        /// <summary>
        /// Gets the <see cref="Int16"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="Int16"/>.</returns>
        public static Int16 GetInt16(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(Int16) : property.Value<Int16>();
        }

        /// <summary>
        /// Gets the <see cref="Int16"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Int16"/>.</returns>
        public static Int16 GetInt16(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(Int16) : token.Value<Int16>();
        }

        /// <summary>
        /// Gets the <see cref="UInt16"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="UInt16"/>.</returns>
        public static UInt16 GetUInt16(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(UInt16) : property.Value<UInt16>();
        }

        /// <summary>
        /// Gets the <see cref="UInt16"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="UInt16"/>.</returns>
        public static UInt16 GetUInt16(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(UInt16) : token.Value<UInt16>();
        }

        /// <summary>
        /// Gets the <see cref="Int32"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="Int32"/>.</returns>
        public static int GetInt32(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(int) : property.Value<int>();
        }

        /// <summary>
        /// Gets the <see cref="Int32"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Int32"/>.</returns>
        public static int GetInt32(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(int) : token.Value<int>();
        }
        
        /// <summary>
        /// Gets the <see cref="UInt32"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="UInt32"/>.</returns>
        public static UInt32 GetUInt32(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(UInt32) : property.Value<UInt32>();
        }

        /// <summary>
        /// Gets the <see cref="UInt32"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="UInt32"/>.</returns>
        public static UInt32 GetUInt32(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(UInt32) : token.Value<UInt32>();
        }
        
        /// <summary>
        /// Gets the <see cref="Int64"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="Int64"/>.</returns>
        public static long GetInt64(this JArray array, int index) {
            if (array == null) return default(long);
            JToken property = array[index];
            return property == null ? default(long) : property.Value<long>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JArray array, string path) {
            if (array == null) return default(long);
            JToken token = array.SelectToken(path);
            return token == null ? default(long) : token.Value<long>();
        }
        
        /// <summary>
        /// Gets the <see cref="UInt64"/> value of the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="UInt64"/>.</returns>
        public static UInt64 GetUInt64(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(UInt64) : property.Value<UInt64>();
        }

        /// <summary>
        /// Gets the <see cref="UInt64"/> value of the token matching the specified <paramref name="path"/>, or
        /// <c>0</c> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="UInt64"/>.</returns>
        public static UInt64 GetUInt64(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(UInt64) : token.Value<UInt64>();
        }
        
        /// <summary>
        /// Gets the <see cref="Double"/> value of the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="Double"/>.</returns>
        public static double GetDouble(this JArray array, int index) {
            if (array == null) return default(double);
            JToken property = array[index];
            return property == null ? default(double) : property.Value<double>();
        }

        /// <summary>
        /// Gets the <see cref="Double"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Double"/>.</returns>
        public static double GetDouble(this JArray array, string path) {
            if (array == null) return default(double);
            JToken token = array.SelectToken(path);
            return token == null ? default(double) : token.Value<double>();
        }

        /// <summary>
        /// Gets the <see cref="Boolean"/> value of the item at the specified <paramref name="index"/> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="Boolean"/>.</returns>
        public static bool GetBoolean(this JArray array, int index) {
            if (array == null) return default(bool);
            JToken property = array[index];
            return property != null && property.Value<bool>();
        }

        /// <summary>
        /// Gets the <see cref="Boolean"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="Boolean"/>.</returns>
        public static bool GetBoolean(this JArray array, string path) {
            if (array == null) return default(bool);
            JToken token = array.SelectToken(path);
            return token != null && token.Value<bool>();
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the item at the specified <paramref name="index"/> in the
        /// array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray GetArray(this JArray array, int index) {
            return array == null ? null : array[index] as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the item at the specified <paramref name="index"/> in the
        /// array using the specified delegate <paramref name="func"/> for parsing each item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetArray<T>(this JArray array, int index, Func<JObject, T> func) {

            JArray property = array?[index] as JArray;
            if (property == null) return null;

            return (
                from JObject child in property
                select func(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray GetArray(this JArray array, string path) {
            return array == null ? null : array.SelectToken(path) as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from the from the token matching the specified
        /// <paramref name="path"/> in the array using the specified delegate <paramref name="func"/> for parsing each
        /// item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetArray<T>(this JArray array, string path, Func<JObject, T> func) {

            JArray token = array?.SelectToken(path) as JArray;
            if (token == null) return null;

            return (
                from JObject child in token
                select func(child)
            ).ToArray();

        }

    }

}