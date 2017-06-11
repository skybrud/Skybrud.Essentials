using System;
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
        /// Parses the specified <code>json</code> string into an instance <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JObject"/> parsed from the specified <code>json</code> string.</returns>
        public static JObject ParseJsonObject(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JObject.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return func(ParseJsonObject(json));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>Returns an instance of <see cref="JObject"/>.</returns>
        public static JObject LoadJsonObject(string path) {
            return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <code>path</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code>.</returns>
        public static T LoadJsonObject<T>(string path, Func<JObject, T> func) {
            return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8), func);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JArray"/> parsed from the specified <code>json</code> string.</returns>
        public static JArray ParseJsonArray(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JArray.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an array of <code>T</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an array of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return (
                from JObject item in ParseJsonArray(json)
                select func(item)
            ).ToArray();
        }

        /// <summary>
        /// Loads and parses the JSON array in the file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>Returns an instance of <see cref="JArray"/>.</returns>
        public static JArray LoadJsonArray(string path) {
            return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8));
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <code>path</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code>.</returns>
        public static T[] LoadJsonArray<T>(string path, Func<JObject, T> func) {
            return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8), func);
        }
        
        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <code>path</code>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonObject(string path, JsonObjectBase obj) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (obj == null) throw new ArgumentNullException("obj");
            SaveJsonObject(path, obj, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <code>path</code>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonObject(string path, JsonObjectBase obj, Formatting formatting) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (obj == null) throw new ArgumentNullException("obj");
            if (obj.JObject == null) throw new PropertyNotSetException("obj.JObject");
            SaveJsonObject(path, obj.JObject, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <see cref="JObject"/> to the file at <code>path</code>. If the file doesn't already
        /// exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonObject(string path, JObject obj) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (obj == null) throw new ArgumentNullException("obj");
            SaveJsonObject(path, obj, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <see cref="JObject"/> to the file at <code>path</code>. If the file doesn't already
        /// exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonObject(string path, JObject obj, Formatting formatting) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (obj == null) throw new ArgumentNullException("obj");
            File.WriteAllText(path, obj.ToString(formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified <see cref="JArray"/> to the file at <code>path</code>. If the file doesn't already
        /// exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
        public static void SaveJsonArray(string path, JArray array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified <see cref="JArray"/> to the file at <code>path</code>. If the file doesn't already
        /// exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JArray array, Formatting formatting) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (array == null) throw new ArgumentNullException("array");
            File.WriteAllText(path, array.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified array of <see cref="JToken"/> to the file at <code>path</code>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
        public static void SaveJsonArray(string path, JToken[] array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified array of <see cref="JToken"/> to the file at <code>path</code>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JToken[] array, Formatting formatting) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (array == null) throw new ArgumentNullException("array");
            File.WriteAllText(path, JsonConvert.SerializeObject(array, formatting), Encoding.UTF8);
        }

        /// <summary>
        /// Saves the specified array of <see cref="JsonObjectBase"/> to the file at <code>path</code>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        public static void SaveJsonArray(string path, JsonObjectBase[] array) {
            SaveJsonArray(path, array, Formatting.None);
        }

        /// <summary>
        /// Saves the specified array of <see cref="JsonObjectBase"/> to the file at <code>path</code>. If the file
        /// doesn't already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        public static void SaveJsonArray(string path, JsonObjectBase[] array, Formatting formatting) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (array == null) throw new ArgumentNullException("array");
            File.WriteAllText(path, JsonConvert.SerializeObject(from item in array select item == null ? null : item.JObject, formatting), Encoding.UTF8);
        }
    
    }

}