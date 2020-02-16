using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;

namespace Skybrud.Essentials.Json {

    /// <summary>
    /// Utility class with various static helper methods for working with JSON.
    /// </summary>
    public static class JsonUtils {

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <see cref="JToken"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static JToken ParseJsonToken(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JToken.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T ParseJsonToken<T>(string json) {
            return ParseJsonToken(json).ToObject<T>();
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JToken"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T ParseJsonToken<T>(string json, Func<JToken, T> func) {
            return func(ParseJsonObject(json));
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static JObject ParseJsonObject(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JObject.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T ParseJsonObject<T>(string json) {
            return ParseJsonObject(json).ToObject<T>();
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return func(ParseJsonObject(json));
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JArray"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static JArray ParseJsonArray(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JArray.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return (
                from JObject item in ParseJsonArray(json)
                select func(item)
            ).ToArray();
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type that each item should be parsed into.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        public static T[] ParseJsonArray<T>(string json) {
            return (
                from JObject item in ParseJsonArray(json)
                select item.ToObject<T>()
            ).ToArray();
        }

#if I_CAN_HAZ_FILE

        /// <summary>
        /// Loads and parses the JSON token in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <see cref="JObject"/>.</returns>
        public static JToken LoadJsonToken(string path) {
            return ParseJsonToken(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T LoadJsonToken<T>(string path) {
            return LoadJsonToken(path).ToObject<T>();
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JToken"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T LoadJsonToken<T>(string path, Func<JToken, T> func) {
            return ParseJsonToken(File.ReadAllText(path, Encoding.UTF8), func);
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <see cref="JObject"/>.</returns>
        public static JObject LoadJsonObject(string path) {
            return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T LoadJsonObject<T>(string path) {
            return LoadJsonObject(path).ToObject<T>();
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T LoadJsonObject<T>(string path, Func<JObject, T> func) {
            return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8), func);
        }

        /// <summary>
        /// Loads and parses the JSON array in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        public static JArray LoadJsonArray(string path) {
            return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
        /// an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T[] LoadJsonArray<T>(string path, Func<JObject, T> func) {
            return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8), func);
        }
        
        /// <summary>
        /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonObject(string path, JsonObjectBase obj) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            SaveJsonObject(path, obj, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonObject(string path, JsonObjectBase obj, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj.JObject == null) throw new PropertyNotSetException(nameof(obj.JObject));
            SaveJsonObject(path, obj.JObject, formatting);
        }

        /// <summary>
        /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonObject(string path, JObject obj) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            SaveJsonObject(path, obj, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonObject(string path, JObject obj, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            File.WriteAllText(path, obj.ToString(formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonArray(string path, JArray array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <see cref="JArray"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JArray array, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (array == null) throw new ArgumentNullException(nameof(array));
            File.WriteAllText(path, array.ToString(formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonArray(string path, JObject[] array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JObject[] array, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (array == null) throw new ArgumentNullException(nameof(array));
            File.WriteAllText(path, JsonConvert.SerializeObject(array, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonArray(string path, IEnumerable<JObject> collection) {
            SaveJsonArray(path, collection, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, IEnumerable<JObject> collection, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            File.WriteAllText(path, JsonConvert.SerializeObject(collection, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
        public static void SaveJsonArray(string path, JToken[] array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JToken[] array, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (array == null) throw new ArgumentNullException(nameof(array));
            File.WriteAllText(path, JsonConvert.SerializeObject(array, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JToken"/> to be saved.</param>
        public static void SaveJsonArray(string path, IEnumerable<JToken> collection) {
            SaveJsonArray(path, collection, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JToken"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, IEnumerable<JToken> collection, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            File.WriteAllText(path, JsonConvert.SerializeObject(collection, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonArray(string path, JsonObjectBase[] array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JsonObjectBase[] array, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (array == null) throw new ArgumentNullException(nameof(array));
            File.WriteAllText(path, JsonConvert.SerializeObject(from item in array select item?.JObject, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonArray<T>(string path, T[] array) where T : JsonObjectBase {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray<T>(string path, T[] array, Formatting formatting) where T : JsonObjectBase {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (array == null) throw new ArgumentNullException(nameof(array));
            File.WriteAllText(path, JsonConvert.SerializeObject(from item in array select item?.JObject, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonArray(string path, IEnumerable<JsonObjectBase> collection) {
            SaveJsonArray(path, collection, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="collection">The collection of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, IEnumerable<JsonObjectBase> collection, Formatting formatting) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            File.WriteAllText(path, JsonConvert.SerializeObject(from item in collection select item?.JObject, formatting), Encoding.UTF8);
        }

#endif

    }

}