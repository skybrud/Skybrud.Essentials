using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Extensions {
    
    /// <summary>
    /// Various extensions methods for <see cref="JObject"/> that makes manual parsing easier.
    /// </summary>
    public static class JObjectExtensions {

        /// <summary>
        /// Gets whether a token matching the specified <paramref name="path"/> exists and isn't <code>null</code> (or an empty string).
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns><code>true</code> if the property exists and the value isn't <code>null</code>, otherwise <code>false</code>.</returns>
        public static bool HasValue(this JObject obj, string path) {
            JToken token = obj == null ? null : obj.SelectToken(path);
            return !(
                token == null
                ||
                (token.Type == JTokenType.Array && !token.HasValues)
                ||
                (token.Type == JTokenType.Object && !token.HasValues)
                ||
                (token.Type == JTokenType.String && token.ToString() == String.Empty)
                ||
                token.Type == JTokenType.Null
            );
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JObject"/>, or <code>null</code> if not found.</returns>
        public static JObject GetObject(this JObject obj, string path) {
            if (obj == null) return null;
            return obj.SelectToken(path) as JObject;
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not found.</returns>
        public static T GetObject<T>(this JObject obj, string path) {
            if (obj == null) return default(T);
            JObject child = obj.SelectToken(path) as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from a token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not found.</returns>
        public static T GetObject<T>(this JObject obj, string path, Func<JObject, T> func) {
            return obj == null ? default(T) : func(obj.SelectToken(path) as JObject);
        }

        /// <summary>
        /// Gets the string value of the token matching the specified <paramref name="path"/>, or <code>null</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="String"/>, or <code>null</code>.</returns>
        public static string GetString(this JObject obj, string path) {
            if (obj == null) return null;
            JToken token = GetSimpleTypeTokenFromPath(obj, path);
            return token == null ? null : token.Value<string>();
        }

        /// <summary>
        /// Gets the value of the token matching the specified <paramref name="path"/>, or <code>null</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the string value.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <code>null</code>.</returns>
        public static T GetString<T>(this JObject obj, string path, Func<string, T> callback) {
            if (obj == null) return default(T);
            JToken token = GetSimpleTypeTokenFromPath(obj, path);
            return token == null ? default(T) : callback(token.Value<string>());
        }

        /// <summary>
        /// Gets the <see cref="System.Int16"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int16"/>.</returns>
        public static Int16 GetInt16(this JObject obj, string path) {
            return GetInt16(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.Int16"/> value of the token matching the specified <paramref name="path"/> and
        /// parses it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if
        /// <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <typeparam name="T">The type of the parsed type.</typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        /// <returns>An instance of <see cref="System.Int16"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetInt16<T>(this JObject obj, string path, Func<Int16, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt16"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.UInt16"/>.</returns>
        public static UInt16 GetUInt16(this JObject obj, string path) {
            return GetUInt16(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt16"/> value of the token matching the specified <paramref name="path"/> and
        /// parses it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if
        /// <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <typeparam name="T">The type of the parsed type.</typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        /// <returns>An instance of <see cref="System.UInt16"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetUInt16<T>(this JObject obj, string path, Func<UInt16, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int32"/>.</returns>
        public static int GetInt32(this JObject obj, string path) {
            return GetInt32(obj, path, x => x);
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
        /// <returns>An instance of <see cref="System.Int32"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetInt32<T>(this JObject obj, string path, Func<int, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt32"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.UInt32"/>.</returns>
        public static uint GetUInt32(this JObject obj, string path) {
            return GetUInt32(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt32"/> value of the token matching the specified <paramref name="path"/> and
        /// parses it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if
        /// <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <typeparam name="T">The type of the parsed type.</typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        /// <returns>An instance of <see cref="System.UInt32"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetUInt32<T>(this JObject obj, string path, Func<uint, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JObject obj, string path) {
            return GetInt64(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the token value.</param>
        /// <returns>An instance of <see cref="System.Int64"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetInt64<T>(this JObject obj, string path, Func<long, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt64"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.UInt64"/>.</returns>
        public static ulong GetUInt64(this JObject obj, string path) {
            return GetUInt64(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.UInt64"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the token value.</param>
        /// <returns>An instance of <see cref="System.UInt64"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetUInt64<T>(this JObject obj, string path, Func<ulong, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Int64"/>.</returns>
        public static float GetFloat(this JObject obj, string path) {
            return GetFloat(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Single"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetFloat<T>(this JObject obj, string path, Func<float, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Double"/>.</returns>
        public static double GetDouble(this JObject obj, string path) {
            return GetDouble(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <paramref name="path"/> and parses
        /// it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Double"/>, or <code>0</code> if <paramref name="path"/> doesn't
        /// match a token.</returns>
        public static T GetDouble<T>(this JObject obj, string path, Func<double, T> callback) {
            return GetSimpleTypeTokenValueFromPath(obj, path, callback);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <paramref name="path"/>, or
        /// <code>0</code> if <paramref name="path"/> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="System.Boolean"/>.</returns>
        public static bool GetBoolean(this JObject obj, string path) {
            return GetBoolean(obj, path, x => x);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <paramref name="path"/> and
        /// parses it into an instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if <paramref name="path"/>
        /// doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An instance of <see cref="System.Boolean"/>, or <code>false</code> if <paramref name="path"/>
        /// doesn't match a token.</returns>
        public static T GetBoolean<T>(this JObject obj, string path, Func<bool, T> callback) {

            // Get the token from the path
            JToken token = GetSimpleTypeTokenFromPath(obj, path);

            // Check whether the token is null
            if (token == null || token.Type == JTokenType.Null) return default(T);

            // Convert the value to a boolean
            bool value = StringUtils.ParseBoolean(token + "");

            // Invoke the callback and return the value
            return callback(value);

        }

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnum<T>(this JObject obj, string path) where T : struct {
            return EnumUtils.ParseEnum<T>(GetString(obj, path));
        }

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        public static T GetEnum<T>(this JObject obj, string path, T fallback) where T : struct {
            string value = GetString(obj, path);
            return String.IsNullOrWhiteSpace(value) ? fallback : EnumUtils.ParseEnum(value, fallback);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the value of the property.</returns>
        public static DateTime GetDateTime(this JObject obj, string path) {
            if (obj == null) return default(DateTime);
            JToken token = obj.SelectToken(path);
            if (token == null || token.Type == JTokenType.Null) return default(DateTime);
            return token.Type == JTokenType.Date ? token.Value<DateTime>() : DateTime.Parse(token.Value<string>());
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
        public static DateTime GetDateTime(this JObject obj, string path, DateTimeStyles styles) {
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
        public static DateTime GetDateTime(this JObject obj, string path, IFormatProvider provider, DateTimeStyles styles) {
            return obj.GetString(path, x => DateTime.Parse(x, provider, styles));
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JArray"/>, or <code>null</code> if not found.</returns>
        public static JArray GetArray(this JObject obj, string path) {
            if (obj == null) return null;
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? null : token as JArray;
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> from a property with the specified <code>propertyName</code> using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        public static T[] GetArray<T>(this JObject obj, string path, Func<JObject, T> callback) {

            if (obj == null) return null;

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return null;

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An array of <see cref="JToken"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static JToken[] GetArrayItems(this JObject obj, string path) {
            JArray array = GetArray(obj, path);
            return array == null ? new JToken[0] : array.ToArray();
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JToken child in token
                select child.Value<T>()
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path, Func<JToken, T> callback) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path, Func<JObject, T> callback) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>An array of <typeparamref name="TValue"/>. If the a matching token isn't found, an empty
        /// array will still be returned.</returns>
        public static TValue[] GetArrayItems<TKey, TValue>(this JObject obj, string path, Func<TKey, TValue> callback) where TKey : JToken {

            if (obj == null) return new TValue[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new TValue[0];

            return (
                from TKey child in token
                select callback(child)
            ).ToArray();
        
        }

        /// <summary>
        /// Gets an array of <see cref="System.String"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="System.String"/>.</returns>
        public static string[] GetStringArray(this JObject obj, string path) {
            return GetArrayItems<string>(obj, path);
        }

        /// <summary>
        /// Gets an array of <see cref="System.Int32"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="System.Int32"/>.</returns>
        public static int[] GetInt32Array(this JObject obj, string path) {
            return GetArrayItems<int>(obj, path);
        }

        /// <summary>
        /// Gets an array of <see cref="System.Int64"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="System.Int64"/>.</returns>
        public static long[] GetInt64Array(this JObject obj, string path) {
            return GetArrayItems<long>(obj, path);
        }

        /// <summary>
        /// Gets an array of <see cref="JObject"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>The token value as an array of <see cref="JObject"/>.</returns>
        public static JObject[] GetObjectArray(this JObject obj, string path) {
            return GetArrayItems<JObject>(obj, path);
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> at the specified <paramref name="path"/>. If the type of <code>token</code> is
        /// either <see cref="JTokenType.Object"/> or <see cref="JTokenType.Array"/>, the method will return
        /// <code>null</code> instead.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>An instance of <see cref="JToken"/>, or <code>null</code>.</returns>
        private static JToken GetSimpleTypeTokenFromPath(JObject obj, string path) {
            JToken token = obj == null ? null : obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Object || token.Type == JTokenType.Array ? null : token;
        }

        private static TOut GetSimpleTypeTokenValueFromPath<TIn, TOut>(this JObject obj, string path, Func<TIn, TOut> callback) {

            // Get the token from the path
            JToken token = GetSimpleTypeTokenFromPath(obj, path);

            // Check whether the token is null
            if (token == null || token.Type == JTokenType.Null) return default(TOut);

            // Check whether the token is an empty string (or whitespace)
            if (token.Type == JTokenType.String && String.IsNullOrWhiteSpace(token + "")) return default(TOut);

            // Cast/convert the value from "TIn" to "TOut"
            TIn value = token.Value<TIn>();

            // Invoke the callback and return the value
            return callback(value);

        }

    }

}