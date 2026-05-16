using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Essentials.Http.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="HttpContent"/> class.
/// </summary>
public static class HttpContentExtensions {

    /// <summary>
    /// Reads the HTTP content as a string and parses it as a JSON array.
    /// </summary>
    /// <param name="content">The HTTP content containing a JSON array.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JArray"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<JArray> ReadAsJsonArrayAsync(this HttpContent content) {
        return JsonUtils.ParseJsonArray(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string and deserializes it to an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type to deserialize each JSON object into.</typeparam>
    /// <param name="content">The HTTP content containing a JSON array.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<T[]> ReadAsJsonArrayAsync<T>(this HttpContent content) {
        return JsonUtils.ParseJsonArray<T>(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string, parses it as a JSON array, and projects each element using the specified function.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="content">The HTTP content containing a JSON array.</param>
    /// <param name="func">A function that maps each parsed <see cref="JObject"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of values returned by <paramref name="func"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> or <paramref name="func"/> is <see langword="null"/>.</exception>
    public static async Task<T[]> ReadAsJsonArrayAsync<T>(this HttpContent content, Func<JObject, T> func) {
        return JsonUtils.ParseJsonArray(await content.ReadAsStringAsync(), func);
    }

    /// <summary>
    /// Reads the HTTP content as a string and parses it as a JSON object.
    /// </summary>
    /// <param name="content">The HTTP content containing a JSON object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JObject"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<JObject> ReadAsJsonObjectAsync(this HttpContent content) {
        return JsonUtils.ParseJsonObject(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string and deserializes it to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to deserialize the JSON into.</typeparam>
    /// <param name="content">The HTTP content containing JSON.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the deserialized instance of <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<T> ReadAsJsonObjectAsync<T>(this HttpContent content) {
        return JsonUtils.ParseJsonObject<T>(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string, parses it as a JSON object, and projects it using the specified function.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="content">The HTTP content containing a JSON object.</param>
    /// <param name="func">A function that maps the parsed <see cref="JObject"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the value returned by <paramref name="func"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
    public static async Task<T> ReadAsJsonObjectAsync<T>(this HttpContent content, Func<JObject, T> func) {
        return JsonUtils.ParseJsonObject(await content.ReadAsStringAsync(), func);
    }

    /// <summary>
    /// Reads the HTTP content as a string and parses it as a JSON token.
    /// </summary>
    /// <param name="content">The HTTP content containing JSON.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JToken"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<JToken> ReadAsJsonTokenAsync(this HttpContent content) {
        return JsonUtils.ParseJsonToken(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string and deserializes it to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON token into.</typeparam>
    /// <param name="content">The HTTP content containing JSON.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> is <see langword="null"/>.</exception>
    public static async Task<T> ReadAsJsonTokenAsync<T>(this HttpContent content) {
        return JsonUtils.ParseJsonToken<T>(await content.ReadAsStringAsync());
    }

    /// <summary>
    /// Reads the HTTP content as a string, parses it as a JSON token, and projects it using the specified function.</summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="content">The HTTP content containing JSON.</param>
    /// <param name="func">A function that maps the parsed <see cref="JToken"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the value returned by <paramref name="func"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="content"/> or <paramref name="func"/> is <see langword="null"/>.</exception>
    public static async Task<T> ReadAsJsonTokenAsync<T>(this HttpContent content, Func<JToken, T> func) {
        return JsonUtils.ParseJsonToken(await content.ReadAsStringAsync(), func);
    }

}