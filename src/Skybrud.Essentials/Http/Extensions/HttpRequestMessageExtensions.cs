using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Skybrud.Essentials.Http.Extensions;

/// <summary>
/// Static class with extension methods for <see cref="HttpRequestMessage"/>. These methods can be used to fluently modify an instance of <see cref="HttpRequestMessage"/>.
/// </summary>
public static class HttpRequestMessageExtensions {

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAccept(this HttpRequestMessage request, string? value) {
        request.Headers.WithAccept(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to the specified <paramref name="value"/>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAccept(this HttpRequestMessage request, MediaTypeWithQualityHeaderValue? value) {
        request.Headers.WithAccept(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Accept</c> header to <c>application/json</c>. Existing <c>Accept</c> values are cleared.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAcceptJson(this HttpRequestMessage request) {
        request.Headers.WithAcceptJson();
        return request;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAcceptLanguage(this HttpRequestMessage request, string? value) {
        request.Headers.WithAcceptLanguage(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Accept-Language</c> header. Existing values are cleared before adding the new language.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">A language tag such as <c>en-US</c> or <c>da-DK</c>.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAcceptLanguage(this HttpRequestMessage request, StringWithQualityHeaderValue? value) {
        request.Headers.WithAcceptLanguage(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestMessage"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAuthorization(this HttpRequestMessage request, string? value) {
        request.Headers.WithAuthorization(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestMessage"/> to the specified <paramref name="scheme"/> and <paramref name="parameter"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="scheme">The authentication scheme.</param>
    /// <param name="parameter">The authentication parameter.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAuthorization(this HttpRequestMessage request, string scheme, string parameter) {
        request.Headers.WithAuthorization(scheme, parameter);
        return request;
    }

    /// <summary>
    /// Sets the <c>Authorization</c> header of the <see cref="HttpRequestMessage"/> to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The value for the <c>Authorization</c> header.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithAuthorization(this HttpRequestMessage request, AuthenticationHeaderValue? value) {
        request.Headers.WithAuthorization(value);
        return request;
    }

    /// <summary>
    /// Sets the "Authorization" header of the <see cref="HttpRequestMessage"/> to use a Bearer token with the specified value.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="token">The Bearer token to set.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithBearerToken(this HttpRequestMessage request, string? token) {
        request.Headers.WithBearerToken(token);
        return request;
    }

    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The <c>User-Agent</c> value to set.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithUserAgent(this HttpRequestMessage request, string? value) {
        request.Headers.WithUserAgent(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>User-Agent</c> header using a product name and version. Existing User-Agent values are cleared
    /// before adding the new value.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="product">The product name.</param>
    /// <param name="version">The product version.</param>
    /// <param name="comment">Optional comment value (without parentheses). For example: <c>+https://example.com</c>.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>

    public static HttpRequestMessage WithUserAgent(this HttpRequestMessage request, string product, string version, string? comment = null) {
        request.Headers.WithUserAgent(product, version, comment);
        return request;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set. Should be a valid URI.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithReferrer(this HttpRequestMessage request, string? value) {
        request.Headers.WithReferrer(value);
        return request;
    }

    /// <summary>
    /// Sets the <c>Referer</c> header.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> instance to modify.</param>
    /// <param name="value">The <c>Referer</c> value to set.</param>
    /// <returns>The modified <see cref="HttpRequestMessage"/> instance.</returns>
    public static HttpRequestMessage WithReferrer(this HttpRequestMessage request, Uri? value) {
        request.Headers.WithReferrer(value);
        return request;
    }

}