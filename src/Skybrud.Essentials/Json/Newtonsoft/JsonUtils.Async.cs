using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft;

public partial class JsonUtils {

#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER

    /// <summary>
    /// Loads and parses the <see cref="JArray"/> from the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JArray"/> parsed from the file at the specified <paramref name="path"/>.</returns>
    public static async Task<JArray> LoadJsonArrayAsync(string path) {
        return ParseJsonArray(await File.ReadAllTextAsync(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the <see cref="JArray"/> from the file at the specified <paramref name="path"/> and converts each item in the array using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the array.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="TItem"/>.</param>
    /// <returns>An array of <typeparamref name="TItem"/> parsed from the file at the specified <paramref name="path"/>.</returns>
    public static async Task<TItem[]> LoadJsonArrayAsync<TItem>(string path, Func<JObject, TItem> func) {
        return ParseJsonArray(await File.ReadAllTextAsync(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Loads and parses the JSON object from the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JObject"/> parsed from the file at the specified <paramref name="path"/>.</returns>
    public static async Task<JObject> LoadJsonObjectAsync(string path) {
        return ParseJsonObject(await File.ReadAllTextAsync(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to be returned.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
    /// an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
    public static async Task<TResult> LoadJsonObjectAsync<TResult>(string path, Func<JObject, TResult> func) {
        return ParseJsonObject(await File.ReadAllTextAsync(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Loads and parses the JSON token from the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JToken"/> parsed from the file at the specified <paramref name="path"/>.</returns>
    public static async Task<JToken> LoadJsonTokenAsync(string path) {
        return ParseJsonToken(await File.ReadAllTextAsync(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the JSON token from the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the value produced from the parsed JSON token.</typeparam>
    /// <param name="path">The path to the JSON file to read.</param>
    /// <param name="func">A function that maps the parsed <see cref="JToken"/> to a <typeparamref name="TResult"/> value.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> parsed from the file at the specified <paramref name="path"/>.</returns>
    public static async Task<TResult> LoadJsonTokenAsync<TResult>(string path, Func<JToken, TResult> func) {
        return ParseJsonToken(await File.ReadAllTextAsync(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Saves the specified <paramref name="json" /> object to a file at <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="json">The JSON object to be saved</param>
    public static async Task SaveJsonObjectAsync(string path, JObject json) {
        await SaveJsonObjectAsync(path, json, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="json" /> object to a file at <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="json">The JSON object to be saved</param>
    /// <param name="formatting">The formatting to be used when saving the JSON object.</param>
    public static async Task SaveJsonObjectAsync(string path, JObject json, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (json == null) throw new ArgumentNullException(nameof(json));
        await File.WriteAllTextAsync(path, json.ToString(formatting), Encoding.UTF8);
    }

#endif

}