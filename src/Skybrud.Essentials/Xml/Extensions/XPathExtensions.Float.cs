#if NETSTANDARD1_3_OR_GREATER || NET45_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Strings;

using XmlException = Skybrud.Essentials.Xml.Exceptions.XmlException;

namespace Skybrud.Essentials.Xml.Extensions;

public partial class XPathExtensions {

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a single-precision floating point number, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The single-precision floating point number.</returns>
    public static float GetFloatValue(this XElement element, string expression) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out float result) ? result : 0;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a single-precision floating point number, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The single-precision floating point number.</returns>
    public static  float GetFloatValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out float result) ? result : 0;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a single-precision floating point number, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The single-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float GetFloatValue(this XElement element, string expression, float fallback) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out float result) ? result : fallback;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a single-precision floating point number, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The single-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float GetFloatValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, float fallback) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out float result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to first a single-precision floating point number, the default value of
    /// <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">A callback function used for converting the single-precision floating point number to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetFloatValue<TResult>(this XElement element, string expression, Func<float, TResult> callback) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out float result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to first a single-precision floating point number, the default value of
    /// <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">A callback function used for converting the single-precision floating point number to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetFloatValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<float, TResult> callback) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out float result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a single-precision floating point number, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The single-precision floating point number.</returns>
    public static  float? GetFloatValueOrNull(this XElement element, string expression) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out float? result) ? result : null;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a single-precision floating point number, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The single-precision floating point number.</returns>
    public static  float? GetFloatValueOrNull(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out float? result) ? result : null;
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a single-precision floating point number, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The value converted to a single-precision floating point number.</returns>
    public static  float GetRequiredFloatValue(this XElement element, string expression) {
        return GetRequiredFloatValue(element, expression, null);
    }

    /// <summary>
    /// Returns the single-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a single-precision floating point number, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The value converted to a single-precision floating point number.</returns>
    public static  float GetRequiredFloatValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return StringUtils.TryParseFloat(value, out float result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "single-precision floating point number");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="float"/>, the <see cref="float"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="float"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="float"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the <see cref="float"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredFloatValue<TResult>(this XElement element, string expression, Func<float, TResult> callback) where TResult : notnull {
        return callback(GetRequiredFloatValue(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="float"/>, the <see cref="float"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="float"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="float"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the <see cref="float"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredFloatValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<float, TResult> callback) where TResult : notnull {
        return callback(GetRequiredFloatValue(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get a single-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloatValue(this XElement element, string expression, out float result) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a single-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloatValue(this XElement element, string expression, [NotNullWhen(true)] out float? result) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a single-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloatValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, out float result) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get a single-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloatValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out float? result) {
        return StringUtils.TryParseFloat(GetStringValue(element, expression, resolver), out result);
    }

}

#endif