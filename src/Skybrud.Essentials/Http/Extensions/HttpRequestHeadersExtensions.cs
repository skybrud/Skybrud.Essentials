using System;
using System.Net.Http.Headers;

namespace Skybrud.Essentials.Http.Extensions;

/// <summary>
/// Static class with various extension methods for the <see cref="HttpRequestHeaders"/> class.
/// </summary>
public static class HttpRequestHeadersExtensions {

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAccept(this HttpRequestHeaders headers, string? value) {
        headers.Accept.Clear();
        if (!string.IsNullOrWhiteSpace(value)) headers.Accept.Add(new MediaTypeWithQualityHeaderValue(value));
        return headers;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAccept(this HttpRequestHeaders headers, MediaTypeWithQualityHeaderValue? value) {
        headers.Accept.Clear();
        if (value is not null) headers.Accept.Add(value);
        return headers;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to <c>application/json</c>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAcceptJson(this HttpRequestHeaders headers) {
        headers.Accept.Clear();
        headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return headers;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAcceptLanguage(this HttpRequestHeaders headers, string? value) {
        headers.AcceptLanguage.Clear();
        if (!string.IsNullOrWhiteSpace(value)) headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(value));
        return headers;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAcceptLanguage(this HttpRequestHeaders headers, StringWithQualityHeaderValue? value) {
        headers.AcceptLanguage.Clear();
        if (value is not null) headers.AcceptLanguage.Add(value);
        return headers;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestHeaders"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAuthorization(this HttpRequestHeaders headers, string? value) {
        headers.Authorization = value is null ? null : AuthenticationHeaderValue.Parse(value);
        return headers;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestHeaders"/> to the specified <paramref name="scheme"/> and <paramref name="parameter"/>.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="scheme">The authentication scheme.</param>
    /// <param name="parameter">The authentication parameter.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAuthorization(this HttpRequestHeaders headers, string scheme, string parameter) {
        headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
        return headers;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestHeaders"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithAuthorization(this HttpRequestHeaders headers, AuthenticationHeaderValue? value) {
        headers.Authorization = value;
        return headers;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestHeaders"/> to use a Bearer token with the specified value.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="token">The Bearer token to set.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithBearerToken(this HttpRequestHeaders headers, string? token) {
        headers.Authorization = token is null ? null : new AuthenticationHeaderValue("Bearer", token);
        return headers;
    }

    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The <c>User-Agent</c> value to set.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithUserAgent(this HttpRequestHeaders headers, string? value) {
        headers.UserAgent.Clear();
        if (!string.IsNullOrWhiteSpace(value)) headers.UserAgent.ParseAdd(value);
        return headers;
    }

    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="product">The product name.</param>
    /// <param name="version">The product version.</param>
    /// <param name="comment">Optional comment value (without parentheses). For example: <c>+https://example.com</c>.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>

    public static HttpRequestHeaders WithUserAgent(this HttpRequestHeaders headers, string product, string version, string? comment = null) {
        headers.UserAgent.Clear();
        headers.UserAgent.Add(new ProductInfoHeaderValue(product, version));
        if (!string.IsNullOrWhiteSpace(comment)) headers.UserAgent.Add(new ProductInfoHeaderValue($"({comment})"));
        return headers;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set. Should be a valid URI.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithReferrer(this HttpRequestHeaders headers, string? value) {
        headers.Referrer = string.IsNullOrWhiteSpace(value) ? null : new Uri(value);
        return headers;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="headers">The <see cref="HttpRequestHeaders"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set.</param>
    /// <returns>The modified <see cref="HttpRequestHeaders"/> instance.</returns>
    public static HttpRequestHeaders WithReferrer(this HttpRequestHeaders headers, Uri? value) {
        headers.Referrer = value;
        return headers;
    }

}