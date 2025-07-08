using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft;

public partial class JsonUtils {

#if NET5_0_OR_GREATER

    /// <summary>
    /// Loads and parses the JSON object from the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns></returns>
    public static async Task<JObject> LoadJsonObjectAsync(string path) {
        return ParseJsonObject(await File.ReadAllTextAsync(path, Encoding.UTF8));
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