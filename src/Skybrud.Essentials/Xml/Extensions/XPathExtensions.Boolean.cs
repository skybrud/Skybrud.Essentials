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
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a boolean value, <see langword="false"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The boolean value.</returns>
    public static bool GetBooleanValue(this XElement element, string expression) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out bool result) && result;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a boolean value, <see langword="false"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The boolean value.</returns>
    public static  bool GetBooleanValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out bool result) && result;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the XPath specified <paramref name="expression"/>. If a matching attribute or element isn't found, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The boolean value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBooleanValue(this XElement element, string expression, bool fallback) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out bool result) ? result : fallback;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the XPath specified <paramref name="expression"/>. If a matching attribute or element isn't found, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The boolean value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBooleanValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, bool fallback) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out bool result) ? result : fallback;
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    ///
    /// If a matching attribute or element is found, and the values matches a boolean value, the value is converted to
    /// <typeparamref name="TResult"/> using the specified <paramref name="callback"/> function.
    ///
    /// If a matching attribute or element isn't found, or the value doesn't match a boolean value, the default value
    /// of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the boolean value into an instance of <typeparamref name="TResult"/>.</param>
    public static TResult? GetBooleanValue<TResult>(this XElement element, string expression, Func<bool, TResult> callback) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out bool result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    ///
    /// If a matching attribute or element is found, and the values matches a boolean value, the value is converted to
    /// <typeparamref name="TResult"/> using the specified <paramref name="callback"/> function.
    ///
    /// If a matching attribute or element isn't found, or the value doesn't match a boolean value, the default value
    /// of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the boolean value into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetBooleanValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<bool, TResult> callback) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out bool result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a boolean value, <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The boolean value.</returns>
    public static bool? GetBooleanValueOrNull(this XElement element, string expression) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out bool? result) ? result : null;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a boolean value, <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The boolean value.</returns>
    public static  bool? GetBooleanValueOrNull(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out bool? result) ? result : null;
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a boolean value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The value converted to a boolean value.</returns>
    public static  bool GetRequiredBooleanValue(this XElement element, string expression) {
        return GetRequiredBooleanValue(element, expression, null);
    }

    /// <summary>
    /// Returns the boolean value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a boolean value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The value converted to a boolean value.</returns>
    public static  bool GetRequiredBooleanValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return StringUtils.TryParseBoolean(value, out bool result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "boolean value");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="bool"/>, the <see cref="bool"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="bool"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="bool"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the <see cref="bool"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredBooleanValue<TResult>(this XElement element, string expression, Func<bool, TResult> callback) where TResult : notnull {
        return callback(GetRequiredBooleanValue(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="bool"/>, the <see cref="bool"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="bool"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="bool"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the <see cref="bool"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredBooleanValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<bool, TResult> callback) where TResult : notnull {
        return callback(GetRequiredBooleanValue(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get a boolean value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanValue(this XElement element, string expression, out bool result) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanValue(this XElement element, string expression, [NotNullWhen(true)] out bool? result) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, out bool result) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out bool? result) {
        return StringUtils.TryParseBoolean(GetStringValue(element, expression, resolver), out result);
    }

}

#endif