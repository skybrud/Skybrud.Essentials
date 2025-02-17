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
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <c>0</c> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The signed 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static int GetInt32Value(this XElement element, string expression) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out int result) ? result : 0;
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <c>0</c> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The signed 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static int GetInt32Value(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out int result) ? result : 0;
    }

    /// <summary>
    /// Returns the 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a 32-bit integer value, <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The 32-bit integer value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static int GetInt32Value(this XElement element, string expression, int fallback) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out int result) ? result : fallback;
    }

    /// <summary>
    /// Returns the 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a 32-bit integer value, <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The 32-bit integer value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static int GetInt32Value(this XElement element, string expression, IXmlNamespaceResolver? resolver, int fallback) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out int result) ? result : fallback;
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <c>0</c> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the 32-bit integer value into a corresponding <typeparamref name="TResult"/> value.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetInt32Value<TResult>(this XElement element, string expression, Func<int, TResult> callback) where TResult : notnull {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out int result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <c>0</c> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the 32-bit integer value into a corresponding <typeparamref name="TResult"/> value.</param>
    /// <returns>The signed 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static TResult? GetInt32Value<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<int, TResult> callback) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out int result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The signed 32-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32ValueOrNull(this XElement element, string expression) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out int? result) ? result : null;
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a signed 32-bit integer value, <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The signed 32-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32ValueOrNull(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out int? result) ? result : null;
    }

    /// <summary>
    /// Returns the 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a 32-bit integer value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The value converted to a 32-bit integer.</returns>
    public static int GetRequiredInt32Value(this XElement element, string expression) {
        return GetRequiredInt32Value(element, expression, null);
    }

    /// <summary>
    /// Returns the 32-bit integer value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a 32-bit integer value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The value converted to a 32-bit integer.</returns>
    public static int GetRequiredInt32Value(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return StringUtils.TryParseInt32(value, out int result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "32-bit integer value");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="int"/>, the <see cref="int"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="int"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="int"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the <see cref="int"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredInt32Value<TResult>(this XElement element, string expression, Func<int, TResult> callback) where TResult : notnull {
        return callback(GetRequiredInt32Value(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="int"/>, the <see cref="int"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="int"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="int"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the <see cref="int"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredInt32Value<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<int, TResult> callback) where TResult : notnull {
        return callback(GetRequiredInt32Value(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get a 32-bit integer value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32Value(this XElement element, string expression, out int result) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a 32-bit integer value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32Value(this XElement element, string expression, [NotNullWhen(true)] out int? result) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a 32-bit integer value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32Value(this XElement element, string expression, IXmlNamespaceResolver? resolver, out int result) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get a 32-bit integer value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32Value(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out int? result) {
        return StringUtils.TryParseInt32(GetStringValue(element, expression, resolver), out result);
    }

}

#endif