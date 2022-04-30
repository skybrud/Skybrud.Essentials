using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json {

    /// <summary>
    /// Utility class with various static helper methods for working with JSON.
    /// </summary>
    [Obsolete("Use the JsonUtils class instead.")]
    public static class JsonHelpers {

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static JObject ParseJsonObject(string json) {
            return JsonUtils.ParseJsonObject(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonObject(json, func);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JArray"/> parsed from the specified <paramref name="json"/> string.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static JArray ParseJsonArray(string json) {
            return JsonUtils.ParseJsonArray(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonArray(json, func);
        }

#if I_CAN_HAZ_FILE

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <see cref="JObject"/>.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static JObject LoadJsonObject(string path) {
            return JsonUtils.LoadJsonObject(path);
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static T LoadJsonObject<T>(string path, Func<JObject, T> func) {
            return JsonUtils.LoadJsonObject(path, func);
        }

        /// <summary>
        /// Loads and parses the JSON array in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        /// <returns>An instance of <see cref="JArray"/>.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static JArray LoadJsonArray(string path) {
            return JsonUtils.LoadJsonArray(path);
        }

        /// <summary>
        /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="path">The path to the JSON file.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        [Obsolete("Use the JsonUtils class instead.")]
        public static T[] LoadJsonArray<T>(string path, Func<JObject, T> func) {
            return JsonUtils.LoadJsonArray(path, func);
        }
        
        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        [Obsolete("Use the JsonUtils class instead.")]
        public static void SaveJsonObject(string path, JsonObjectBase obj) {
            JsonUtils.SaveJsonObject(path, obj);
        }

        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        [Obsolete("Use the JsonUtils class instead.")]
        public static void SaveJsonObject(string path, JsonObjectBase obj, Formatting formatting) {
            JsonUtils.SaveJsonObject(path, obj, formatting);
        }

        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        [Obsolete("Use the JsonUtils class instead.")]
        public static void SaveJsonObject(string path, JObject obj) {
            JsonUtils.SaveJsonObject(path, obj);
        }

        /// <summary>
        /// Saves the specified <see cref="JsonObjectBase"/> to the file at <paramref name="path"/>. If the file doesn't
        /// already exist, a new file will be created.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
        /// <param name="formatting">The formatting to be used when saving the object.</param>
        [Obsolete("Use the JsonUtils class instead.")]
        public static void SaveJsonObject(string path, JObject obj, Formatting formatting) {
            JsonUtils.SaveJsonObject(path, obj, formatting);
        }

#endif

    }

}