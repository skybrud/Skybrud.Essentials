#if NETSTANDARD1_0_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Essentials.Http.Extensions;

/// <summary>
/// Static class with extension methods for <see cref="HttpClient"/> and related classes.
/// </summary>
public static class HttpClientExtensions {

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAccept(this HttpClient client, string? value) {
        client.DefaultRequestHeaders.Accept.Clear();
        if (!string.IsNullOrWhiteSpace(value)) client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(value));
        return client;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAccept(this HttpClient client, MediaTypeWithQualityHeaderValue? value) {
        client.DefaultRequestHeaders.Accept.Clear();
        if (value is not null) client.DefaultRequestHeaders.Accept.Add(value);
        return client;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to <c>application/json</c>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAcceptJson(this HttpClient client) {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAcceptLanguage(this HttpClient client, string? value) {
        client.DefaultRequestHeaders.AcceptLanguage.Clear();
        if (!string.IsNullOrWhiteSpace(value)) client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(value));
        return client;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAcceptLanguage(this HttpClient client, StringWithQualityHeaderValue? value) {
        client.DefaultRequestHeaders.AcceptLanguage.Clear();
        if (value is not null) client.DefaultRequestHeaders.AcceptLanguage.Add(value);
        return client;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpClient"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAuthorization(this HttpClient request, string? value) {
        request.DefaultRequestHeaders.WithAuthorization(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpClient"/> to the specified <paramref name="scheme"/> and <paramref name="parameter"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="scheme">The authentication scheme.</param>
    /// <param name="parameter">The authentication parameter.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAuthorization(this HttpClient request, string scheme, string parameter) {
        request.DefaultRequestHeaders.WithAuthorization(scheme, parameter);
        return request;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpClient"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithAuthorization(this HttpClient request, AuthenticationHeaderValue? value) {
        request.DefaultRequestHeaders.WithAuthorization(value);
        return request;
    }

    /// <summary>
    /// Sets the "Authorization" header of the <see cref="HttpClient"/> to use a Bearer token with the specified value.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="token">The Bearer token to set.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithBearerToken(this HttpClient client, string token) {
        client.DefaultRequestHeaders.WithBearerToken(token);
        return client;
    }




    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The <c>User-Agent</c> value to set.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithUserAgent(this HttpClient client, string? value) {
        client.DefaultRequestHeaders.UserAgent.Clear();
        if (!string.IsNullOrWhiteSpace(value)) client.DefaultRequestHeaders.UserAgent.ParseAdd(value);
        return client;
    }

    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="product">The product name.</param>
    /// <param name="version">The product version.</param>
    /// <param name="comment">Optional comment value (without parentheses). For example: <c>+https://example.com</c>.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>

    public static HttpClient WithUserAgent(this HttpClient client, string product, string version, string? comment = null) {
        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(product, version));
        if (!string.IsNullOrWhiteSpace(comment)) client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue($"({comment})"));
        return client;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set. Should be a valid URI.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithReferrer(this HttpClient client, string? value) {
        client.DefaultRequestHeaders.Referrer = string.IsNullOrWhiteSpace(value) ? null : new Uri(value);
        return client;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set.</param>
    /// <returns>The modified <see cref="HttpClient"/> instance.</returns>
    public static HttpClient WithReferrer(this HttpClient client, Uri? value) {
        client.DefaultRequestHeaders.Referrer = value;
        return client;
    }

    /// <summary>
    /// Returns the JSON response from the specified URL as a <see cref="JArray"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JArray"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<JArray> GetJsonArrayAsync(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonArray(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL deserialized to an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The element type to deserialize each JSON object into.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<T[]> GetJsonArrayAsync<T>(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonArray<T>(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL as an array of <typeparamref name="T"/> using the specified projection function.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <param name="func">A function that maps each parsed <see cref="JObject"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of values returned by <paramref name="func"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/>, <paramref name="url"/>, or <paramref name="func"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<T[]> GetJsonArrayAsync<T>(this HttpClient client, string url, Func<JObject, T> func) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        if (func is null) throw new ArgumentNullException(nameof(func));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonArray(body, func);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL as a <see cref="JObject"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JObject"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed, the response was unsuccessful, or the content could not be read.</exception>
    public static async Task<JObject> GetJsonObjectAsync(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonObject(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL deserialized to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to deserialize the JSON into.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the deserialized
    /// instance of <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed, the response was unsuccessful, or the content could not be read.</exception>
    public static async Task<T> GetJsonObjectAsync<T>(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonObject<T>(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL and projects the parsed <see cref="JObject"/> using the specified function.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <param name="func">A function that maps the parsed <see cref="JObject"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the value returned by <paramref name="func"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed, the response was unsuccessful, or the content could not be read.</exception>
    public static async Task<T> GetJsonObjectAsync<T>(this HttpClient client, string url, Func<JObject, T> func) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        if (func is null) throw new ArgumentNullException(nameof(func));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonObject(body, func);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL as a <see cref="JToken"/>.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the parsed <see cref="JToken"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<JToken> GetJsonTokenAsync(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonToken(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL deserialized to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON token into.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized value.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<T> GetJsonTokenAsync<T>(this HttpClient client, string url) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonToken<T>(body);
    }

    /// <summary>
    /// Returns the JSON response from the specified URL and projects the parsed
    /// <see cref="JToken"/> using the specified function.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="client">The <see cref="HttpClient"/> used to send the request.</param>
    /// <param name="url">The URL to request JSON from.</param>
    /// <param name="func">A function that maps the parsed <see cref="JToken"/> to a value of type <typeparamref name="T"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the value returned by <paramref name="func"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/>, <paramref name="url"/>, or <paramref name="func"/> is <see langword="null"/>.</exception>
    /// <exception cref="HttpRequestException">The request failed or the response content could not be read.</exception>
    public static async Task<T> GetJsonTokenAsync<T>(this HttpClient client, string url, Func<JToken, T> func) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (url is null) throw new ArgumentNullException(nameof(url));
        if (func is null) throw new ArgumentNullException(nameof(func));
        string body = await client.GetStringAsync(url);
        return JsonUtils.ParseJsonToken(body, func);
    }

}

#endif